using System;
using System.IO;
using System.Net;

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
        bool SendFile(IFileService fileService, string fileName);
        void Close();
    }
}
