using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Parsifal.Util.Net
{
    public class SimpleTcpClient : IDisposable
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private volatile bool _isConn;
        private readonly IPAddress _remoteAddr;
        private readonly int _remotePort;

        public int BufferSize { get; set; } = 1024;
        public bool Connected { get => _isConn; }
        public event Action<byte[]> ReceiveData;

        public SimpleTcpClient(string serverAddress, int port)
        {
            if (!IPAddress.TryParse(serverAddress, out IPAddress addr))
            {
                addr = Dns.GetHostEntry(serverAddress).AddressList[0];
            }
            _remoteAddr = addr;
            _remotePort = port;
        }

        public void Connect()
        {
            if (_isConn)
                return;
            _client = new TcpClient();
            Task.Factory.StartNew(ConnectToServer);
        }

        public void Disconnect()
        {
            if (!_isConn)
                return;
            _client.Close();
            _isConn = false;
        }

        public void Send(byte[] data)
        {
            if (_isConn)
            {
                _stream?.Write(data, 0, data.Length);
            }
            else
            {
                Console.WriteLine("Not connected to the server");
            }
        }

        public void Dispose()
        {
            InnerDispose();
            GC.SuppressFinalize(this);
        }

        private void InnerDispose()
        {
            try
            {
                _isConn = false;
                if (_stream != null)
                {
                    _stream.Close();
                    _stream.Dispose();
                }
                if (_client != null)
                {
                    _client.Close();
                    ((IDisposable)_client).Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred on {nameof(SimpleTcpClient)} dispose: {ex.GetBriefMessage()}");
            }
        }

        private async Task ConnectToServer()
        {
            try
            {
                await _client.ConnectAsync(_remoteAddr, _remotePort).ConfigureAwait(false);
                _stream = _client.GetStream();
                _isConn = true;
                Console.WriteLine($"Connectd to {_client.Client.RemoteEndPoint}");
                _client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                _ = Task.Factory.StartNew(DataReceive);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred on connect: {ex.GetBriefMessage()}");
                _client?.Close();
            }
        }

        private async Task DataReceive()
        {
            try
            {
                while (true)
                {
                    var buffer = new byte[BufferSize];
                    int count = await (_stream?.ReadAsync(buffer, 0, buffer.Length)).ConfigureAwait(false);
                    if (count > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await ms.WriteAsync(buffer, 0, count).ConfigureAwait(false);
                            var data = ms.ToArray();
                            _ = Task.Factory.StartNew(() => ReceiveData?.Invoke(data));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred on receiving: {ex.GetBriefMessage()}");
            }
            //运行到此处则表示已断开连接
            _isConn = false;
        }
    }
}
