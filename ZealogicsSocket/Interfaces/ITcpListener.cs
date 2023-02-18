using System;

namespace ZealogicsSocket.Interfaces
{
    public interface ITcpListener
    {
        void Start(Action<(string ip, string port, string msg)> callback);
        void Stop();
        ITcpClient AcceptTcpClient();
    }
}
