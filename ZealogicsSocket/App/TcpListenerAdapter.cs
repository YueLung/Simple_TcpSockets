using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ZealogicsSocket.Extensions;
using ZealogicsSocket.Interfaces;
using ZealogicsSocket.Utils;

namespace ZealogicsSocket.App
{
    public class TcpListenerAdapter : ITcpListener
    {
        private TcpListener _listener;

        private IFileService _fileService;

        public TcpListenerAdapter(string localIp, int port, IFileService fileService)
        {
            IPAddress localAddr = IPAddress.Parse(localIp);
            _listener = new TcpListener(localAddr, port);
            _fileService = fileService;
        }

        public TcpListenerAdapter(IPEndPoint localEP, IFileService fileService)
        {
            _listener = new TcpListener(localEP);
            _fileService = fileService;
        }

        public void StartListening(Action<(string ip, string port, string msg)> callback)
        {
            _listener.Start();

            Task task = new Task(() =>
            {
                while (true)
                {
                    TcpClient client = _listener.AcceptTcpClient();
                    Console.WriteLine("客戶端已連線");

                    ITcpClient tcpClient = new TcpClientAdapter(client);

                    try
                    {
                        // 取得網路流
                        //NetworkStream stream = client.GetStream();

                        //// 讀取檔案名稱
                        //var fileNameBytes = new byte[1024];
                        //int bytesRead = stream.Read(fileNameBytes, 0, fileNameBytes.Length);
                        //string fileName = Encoding.ASCII.GetString(fileNameBytes, 0, bytesRead);

                        string fileName = tcpClient.ReceiveMsg();

                        // 取得client ip info
                        //IPEndPoint clientIpEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                        IPEndPoint clientIpEndPoint = tcpClient.RemoteEndPoint as IPEndPoint;
                        callback((clientIpEndPoint.Address.ToString(), clientIpEndPoint.Port.ToString(), fileName));

                        if (fileName != null)
                        {
                            tcpClient.SendFile(_fileService, fileName);

                            //SendFile(client, fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        //var msgBytes = MsgType.Fail.GetBytes();
                        //client.GetStream().Write(msgBytes, 0, msgBytes.Length);

                        tcpClient.SendMsg(MsgType.Fail);

                        //var errorMsg = ex.Message.GetBytes();
                        //client.GetStream().Write(errorMsg, 0, errorMsg.Length);

                        tcpClient.SendMsg(ex.Message);

                        Console.WriteLine("Exception: {0}", ex);
                    }
                }
            });

            task.Start();
        }

        public void Stop() => _listener.Stop();

        public ITcpClient AcceptTcpClient()
        {
            TcpClient tcpClient = _listener.AcceptTcpClient();
            return new TcpClientAdapter(tcpClient);
        }
    }
}
