using System;

namespace ZealogicsSocket.Interfaces
{
    public interface IClient
    {
        string DownloadFile(string ip, string port, string fileName, string savePath);
    }
}
