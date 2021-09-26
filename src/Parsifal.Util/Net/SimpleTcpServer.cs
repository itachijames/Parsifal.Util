using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Parsifal.Util.Net
{
    public class SimpleTcpServer : IDisposable
    {
        private volatile bool _isRunning;
        private readonly TcpListener _server;
        private readonly ConcurrentDictionary<EndPoint, TcpClient> _connClients;

        public int BufferSize { get; set; } = 1024;
        public event Action<EndPoint> ClientConnected;
        public event Action<EndPoint, byte[]> ReceiveDataFrom;
        public event Action<EndPoint> ClientDisconnected;

        public SimpleTcpServer(int port) : this(string.Empty, port) { }
        public SimpleTcpServer(string localAddress, int port)
        {
            IPAddress addr;
            if (string.IsNullOrEmpty(localAddress))
                addr = IPAddress.Any;
            else
                addr = IPAddress.Parse(localAddress);
            _server = new TcpListener(addr, port);
            _server.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

            _isRunning = false;
            _connClients = new ConcurrentDictionary<EndPoint, TcpClient>();
        }

        public void Send(EndPoint clientEP, byte[] data)
        {
            if (_connClients.TryGetValue(clientEP, out var client))
            {
                client.GetStream().Write(data, 0, data.Length);
            }
            else
            {
                Console.WriteLine("Unknow client or client had been disconnected");
            }
        }

        public void Start()
        {
            if (_isRunning)
                return;
            //启动监听
            _server.Start();
            _isRunning = true;
            Task.Factory.StartNew(Listen, TaskCreationOptions.LongRunning);
            Console.WriteLine($"{nameof(SimpleTcpServer)} start at {_server.LocalEndpoint}");
        }

        public void Stop()
        {
            if (!_isRunning)
                return;
            _server.Stop();
            _isRunning = false;
            Console.WriteLine($"{nameof(SimpleTcpServer)} stopped");
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
                if (_connClients?.Count > 0)
                {
                    foreach (var item in _connClients)
                    {
                        item.Value.Close();
                        ((IDisposable)item.Value)?.Dispose();
                    }
                }
                if (_server.Server != null)
                {
                    _server.Server.Close();
                    _server.Server.Dispose();
                }
                _server.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred on {nameof(SimpleTcpServer)} dispose: {ex.GetBriefMessage()}");
            }
        }

        private async Task Listen()
        {
            while (_isRunning)
            {
                try
                {
                    var client = await _server.AcceptTcpClientAsync().ConfigureAwait(false);
                    var clientEP = client.Client.LocalEndPoint;
                    _connClients.TryAdd(clientEP, client);
                    ClientConnected?.Invoke(clientEP);
                    Console.WriteLine($"New client [{clientEP}] connected");
                    _ = Task.Factory.StartNew(() => DataReceive(client));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An exception occurred on listen: {ex.GetBriefMessage()}");
                }
            }
            //如果到此处则表示已停止监听
            _isRunning = false;
        }

        private async Task DataReceive(TcpClient client)
        {
            var ep = client.Client.LocalEndPoint;
            while (client.Connected)
            {
                var buffer = new byte[BufferSize];
                try
                {
                    int count = await (client.GetStream()?.ReadAsync(buffer, 0, buffer.Length)).ConfigureAwait(false);
                    if (count > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            await ms.WriteAsync(buffer, 0, count).ConfigureAwait(false);
                            var data = ms.ToArray();
                            _ = Task.Factory.StartNew(() => ReceiveDataFrom?.Invoke(ep, data));//异步触发事件
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An exception occurred on receiving: {ex.GetBriefMessage()}");
                }
            }
            //如果到此处则表示连接已断开
            ClientDisconnected?.Invoke(ep);
            _connClients.TryRemove(ep, out _);
            ((IDisposable)client)?.Dispose();
        }
    }
}
