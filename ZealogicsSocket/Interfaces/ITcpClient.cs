using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ZealogicsSocket.Interfaces
{
    public interface ITcpClient : IDisposable
    {
        EndPoint RemoteEndPoint { get; }
        NetworkStream GetStream();
        void Connect(string ip, int port);
        void Close();
    }
}
