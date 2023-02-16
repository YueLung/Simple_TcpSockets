using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ZealogicsSocket.Extensions;
using ZealogicsSocket.Interfaces;
using ZealogicsSocket.Utils;

namespace ZealogicsSocket.App
{
    public class Server : IServer
    {
        public string LocalIp { get; }
        public string Port { get; }

        private IFileService _fileService;

        private TcpListener _listener;

        public Server(string localIp, string port, IFileService fileService)
        {
            LocalIp = localIp;
            Port = port;
            _fileService = fileService;
        }

        public void StartListening(Action<(string ip, string port, string fileName)> func)
        {
            try
            {
                IPAddress localAddr = IPAddress.Parse(LocalIp);
                int port = Convert.ToInt32(Port);

                _listener = new TcpListener(localAddr, port);
                _listener.Start();

                Thread thrListening = new Thread(() => Listening(func));
                thrListening.Start();
            }
            catch (SocketException ex)
            {
                Console.WriteLine("SocketException: {0}", ex);
            }
        }

        private void Listening(Action<(string ip, string port, string fileName)> func)
        {
            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                Console.WriteLine("客戶端已連線");

                try
                {
                    // 取得網路流
                    NetworkStream stream = client.GetStream();

                    // 讀取檔案名稱
                    var fileNameBytes = new byte[1024];
                    int bytesRead = stream.Read(fileNameBytes, 0, fileNameBytes.Length);
                    string fileName = Encoding.ASCII.GetString(fileNameBytes, 0, bytesRead);

                    // 取得client ip info
                    IPEndPoint clientIpEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    func((clientIpEndPoint.Address.ToString(), clientIpEndPoint.Port.ToString(), fileName));

                    if (fileName != null)
                    {
                        SendFile(client, fileName);
                    }
                }
                catch (Exception ex)
                {
                    var msgBytes = MsgType.Fail.GetBytes();
                    client.GetStream().Write(msgBytes, 0, msgBytes.Length);

                    var errorMsg = ex.Message.GetBytes();
                    client.GetStream().Write(errorMsg, 0, errorMsg.Length);

                    Console.WriteLine("SocketException: {0}", ex);
                }
            }
        }

        private void SendFile(TcpClient client, string fileName)
        {
            var targetFile = _fileService.GetFilePath(fileName);

            if (targetFile == null)
            {
                var msg = $"Can not find file {fileName}".GetBytes();
                client.GetStream().Write(msg, 0, msg.Length);
                return;
            }

            // 傳送成功訊息
            var successBytes = MsgType.Success.GetBytes();
            client.GetStream().Write(successBytes, 0, successBytes.Length);

            // 傳送檔案包含附檔名
            string fileExtensionName = Path.GetFileName(targetFile);
            var fileNameBytes = fileExtensionName.GetBytes();
            client.GetStream().Write(fileNameBytes, 0, fileNameBytes.Length);

            // 讀取檔案內容
            var fileBytes = File.ReadAllBytes(targetFile);
            // 傳送檔案內容
            client.GetStream().Write(fileBytes, 0, fileBytes.Length);
        }

    }
}
