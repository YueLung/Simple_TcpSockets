using System;

namespace ZealogicsSocket.Interfaces
{
    public interface IServer
    {
        void StartListening(Action<(string ip, string port, string fileName)> func);

        //void SendFile(string fileName);
    }
}
