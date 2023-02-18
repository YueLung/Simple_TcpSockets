using System;
using System.Net;
using System.Threading.Tasks;
using ZealogicsSocket.Interfaces;
using ZealogicsSocket.Utils;

namespace ZealogicsSocket.App
{
    public class ListenerService
    {
        private ITcpListener _tcpListener;

        private IFileService _fileService;

        public ListenerService(ITcpListener tcpListener, IFileService fileService)
        {
            _tcpListener = tcpListener;
            _fileService = fileService;
        }

        public void Start(Action<(string ip, string port, string msg)> callback)
        {
            _tcpListener.Start(callback);

            Task task = new Task(() =>
            {
                while (true)
                {
                    ITcpClient tcpClient = _tcpListener.AcceptTcpClient();
                    Console.WriteLine("客戶端已連線");

                    try
                    {
                        string fileName = tcpClient.ReceiveMsg();

                        // 取得client ip info
                        IPEndPoint clientIpEndPoint = tcpClient.RemoteEndPoint as IPEndPoint;
                        callback((clientIpEndPoint.Address.ToString(), clientIpEndPoint.Port.ToString(), fileName));

                        if (fileName != null)
                        {
                            tcpClient.SendFile(_fileService, fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        tcpClient.SendMsg(MsgType.Fail);
                        tcpClient.SendMsg(ex.Message);

                        Console.WriteLine("Exception: {0}", ex);
                    }
                }
            });

            task.Start();
        }
    }
}
