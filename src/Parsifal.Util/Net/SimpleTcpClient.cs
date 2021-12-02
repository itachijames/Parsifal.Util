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

        /// <summary>
        /// 缓存大小
        /// </summary>
        public int BufferSize { get; set; } = 1024;
        /// <summary>
        /// 连接标识
        /// </summary>
        public bool Connected { get => _isConn; }
        /// <summary>
        /// 接收数据事件
        /// </summary>
        public event Action<byte[]> ReceiveData;

        /// <summary>
        /// 创建连接到指定服务端的TCP客户端
        /// </summary>
        /// <param name="serverAddress">服务器地址</param>
        /// <param name="serverPort">服务器端口</param>
        /// <exception cref="ArgumentNullException">地址为空</exception>
        /// <exception cref="ArgumentOutOfRangeException">地址场地过长或端口超出合理范围</exception>
        /// <exception cref="SocketException">服务器地址解析异常</exception>
        public SimpleTcpClient(string serverAddress, int serverPort)
        {
            if (string.IsNullOrEmpty(serverAddress))
                throw new ArgumentNullException(nameof(serverAddress));
            if (serverPort <= IPEndPoint.MinPort || serverPort >= IPEndPoint.MaxPort)
                throw new ArgumentOutOfRangeException(nameof(serverPort));
            if (!IPAddress.TryParse(serverAddress, out IPAddress addr))
                addr = Dns.GetHostEntry(serverAddress).AddressList[0];
            _remoteAddr = addr;
            _remotePort = serverPort;
        }

        /// <summary>
        /// 连接到服务器
        /// </summary>
        public async void Connect()
        {
            if (_isConn)
                return;
            _client = new TcpClient();
            await Task.Factory.StartNew(ConnectToServer);
        }
        /// <summary>
        /// 断开服务器连接
        /// </summary>
        public void Disconnect()
        {
            if (!_isConn)
                return;
            _client.Close();
            _isConn = false;
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data"></param>
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
                Console.WriteLine($"Connectd to {_client.Client.RemoteEndPoint} (local:{_client.Client.LocalEndPoint})");
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
