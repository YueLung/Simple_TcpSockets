using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ZealogicsSocket.Interfaces;

namespace ZealogicsSocket.App
{
    public class TcpClientAdapter : ITcpClient
    {
        private readonly TcpClient _client;
        public EndPoint RemoteEndPoint => _client.Client.RemoteEndPoint;
        public NetworkStream GetStream() => _client.GetStream();

        public TcpClientAdapter()
        {
            _client = new TcpClient();
        }

        public void Connect(string ip, int port)
        {
            _client.Connect(ip, port);
        }

        public void Close()
        {
            _client.Close();
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
