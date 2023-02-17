using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ZealogicsSocket.Interfaces
{
    public interface ITcpListener
    {
        void StartListening(Action<(string ip, string port, string msg)> callback);
        void Stop();
        ITcpClient AcceptTcpClient();
    }
}
