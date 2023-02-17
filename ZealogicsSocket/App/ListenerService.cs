using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ZealogicsSocket.Interfaces;

namespace ZealogicsSocket.App
{
    public class ListenerService
    {
        private ITcpListener _tcpListener;

        public ListenerService(ITcpListener tcpListener)
        {
            _tcpListener = tcpListener;
        }

        public void Start(Action<(string ip, string port, string msg)> callback)
        {
            _tcpListener.StartListening(callback);
        }
    }
}
