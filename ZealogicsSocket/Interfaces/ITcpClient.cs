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

        Stream GetStream();
        void Connect(string ip, int port);
        string ReceiveMsg();
        void ReceiveFile(string savePath, string fileExtensionName);
        void SendMsg(string msg);
        void SendFile(IFileService fileService, string fileName);
        void Close();
    }
}
