using System;
using System.Net;
using System.Net.Sockets;
using ZealogicsSocket.Interfaces;

namespace ZealogicsSocket.App
{
    public class TcpListenerAdapter : ITcpListener
    {
        private TcpListener _listener;

        public TcpListenerAdapter(string localIp, int port)
        {
            IPAddress localAddr = IPAddress.Parse(localIp);
            _listener = new TcpListener(localAddr, port);
        }

        public TcpListenerAdapter(IPEndPoint localEP, IFileService fileService)
        {
            _listener = new TcpListener(localEP);
        }

        public void Start(Action<(string ip, string port, string msg)> callback)
        {
            _listener.Start();

            //Task task = new Task(() =>
            //{
            //    while (true)
            //    {
            //        TcpClient client = _listener.AcceptTcpClient();
            //        Console.WriteLine("客戶端已連線");

            //        ITcpClient tcpClient = new TcpClientAdapter(client);

            //        try
            //        {
            //            string fileName = tcpClient.ReceiveMsg();

            //            // 取得client ip info
            //            IPEndPoint clientIpEndPoint = tcpClient.RemoteEndPoint as IPEndPoint;
            //            callback((clientIpEndPoint.Address.ToString(), clientIpEndPoint.Port.ToString(), fileName));

            //            if (fileName != null)
            //            {
            //                tcpClient.SendFile(_fileService, fileName);
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            tcpClient.SendMsg(MsgType.Fail);
            //            tcpClient.SendMsg(ex.Message);

            //            Console.WriteLine("Exception: {0}", ex);
            //        }
            //    }
            //});

            //task.Start();
        }

        public void Stop() => _listener.Stop();

        public ITcpClient AcceptTcpClient()
        {
            TcpClient tcpClient = _listener.AcceptTcpClient();
            return new TcpClientAdapter(tcpClient);
        }
    }
}
