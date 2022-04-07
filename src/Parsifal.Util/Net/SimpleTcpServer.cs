using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Parsifal.Util.Net
{
    public class SimpleTcpServer : IDisposable
    {
        private volatile bool _isRunning;
        private TcpListener _server;
        private IPAddress _localAddress;
        private int _localPort;
        private readonly ConcurrentDictionary<EndPoint, TcpClient> _connClients;

        /// <summary>
        /// 缓存大小
        /// </summary>
        public int BufferSize { get; set; } = 1024;
        /// <summary>
        /// 运行标志
        /// </summary>
        public bool Running => _isRunning;
        /// <summary>
        /// 客户端连接事件
        /// </summary>
        public event Action<EndPoint> ClientConnected;
        /// <summary>
        /// 接收客户端数据事件
        /// </summary>
        public event Action<EndPoint, byte[]> ReceiveDataFrom;
        /// <summary>
        /// 客户端断开事件
        /// </summary>
        public event Action<EndPoint> ClientDisconnected;

        /// <summary>
        /// 创建监听指定端口的TCP服务端
        /// </summary>
        /// <param name="localPort">本地端口</param>
        public SimpleTcpServer(int localPort) : this(string.Empty, localPort) { }
        /// <summary>
        /// 创建监听指定地址及端口的TCP服务端
        /// </summary>
        /// <param name="localAddress">本地地址</param>
        /// <param name="localPort">本地端口</param>
        /// <exception cref="FormatException">地址格式问题</exception>
        /// <exception cref="ArgumentException">非本地地址</exception>
        /// <exception cref="ArgumentOutOfRangeException">端口超出合理范围</exception>
        public SimpleTcpServer(string localAddress, int localPort)
        {
            IPAddress addr;
            if (string.IsNullOrEmpty(localAddress))
            {
                addr = IPAddress.Any;
            }
            else
            {
                addr = IPAddress.Parse(localAddress);
                if (!NetHelper.GetLocalIPs().Contains(addr))
                {
                    throw new ArgumentException("Not a local address", nameof(localAddress));
                }
            }
            _localAddress = addr;
            _localPort = localPort;
            _connClients = new ConcurrentDictionary<EndPoint, TcpClient>();
            _isRunning = false;
        }

        /// <summary>
        /// 启动监听
        /// </summary>
        public void Start()
        {
            if (_isRunning)
                return;
            _server = new TcpListener(_localAddress, _localPort);
            _server.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            //启动监听
            _server.Start();
            _isRunning = true;
            Task.Factory.StartNew(Listen, TaskCreationOptions.LongRunning);
            Console.WriteLine($"{nameof(SimpleTcpServer)} start at {_server.LocalEndpoint}");
        }
        /// <summary>
        /// 停止监听
        /// </summary>
        public void Stop()
        {
            if (!_isRunning)
                return;
            _server.Stop();
            _isRunning = false;
            Console.WriteLine($"{nameof(SimpleTcpServer)} stopped");
        }
        /// <summary>
        /// 向指定客户端发送数据
        /// </summary>
        /// <param name="clientEP">客户端</param>
        /// <param name="data">待发送数据</param>
        public void Send(EndPoint clientEP, byte[] data)
        {
            if (_isRunning)
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
            else
            {
                Console.WriteLine("Not running yet");
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
#if NET45_OR_GREATER
            var buffer = new byte[BufferSize];
#else
            var ap = System.Buffers.ArrayPool<byte>.Shared;
            var buffer = ap.Rent(BufferSize);
#endif
            while (client.Connected)
            {
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
#if !NET45_OR_GREATER
                    ap.Return(buffer);
#endif
                }
            }
            //如果到此处则表示连接已断开
            ClientDisconnected?.Invoke(ep);
            _connClients.TryRemove(ep, out _);
            ((IDisposable)client)?.Dispose();
        }
    }
}
