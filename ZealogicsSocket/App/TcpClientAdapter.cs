using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ZealogicsSocket.Extensions;
using ZealogicsSocket.Interfaces;
using ZealogicsSocket.Utils;

namespace ZealogicsSocket.App
{
    public class TcpClientAdapter : ITcpClient
    {
        private TcpClient _tcpClient;

        public EndPoint RemoteEndPoint => _tcpClient.Client.RemoteEndPoint;
        public Stream GetStream() => _tcpClient.GetStream();

        public TcpClientAdapter()
        {
            _tcpClient = new TcpClient();
        }

        public TcpClientAdapter(TcpClient tcpClient)
        {
            _tcpClient = tcpClient;
        }

        public void Connect(string ip, int port)
        {
            _tcpClient.Connect(ip, port);
        }

        public string ReceiveMsg()
        {
            string receiveMsg = string.Empty;

            try
            {
                byte[] receiveBytes = new byte[_tcpClient.ReceiveBufferSize];

                var stream = _tcpClient.GetStream();

                int bytesRead = stream.Read(receiveBytes, 0, receiveBytes.Length);
                receiveMsg = Encoding.ASCII.GetString(receiveBytes, 0, bytesRead);
            }
            catch (Exception ex)
            {
                receiveMsg = ex.Message;
            }

            return receiveMsg;
        }

        public void ReceiveFile(string savePath, string fileExtensionName)
        {
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            var fileBytes = new byte[_tcpClient.ReceiveBufferSize];

            var stream = _tcpClient.GetStream();

            int bytesRead = stream.Read(fileBytes, 0, fileBytes.Length);

            // 接收檔案內容
            using (FileStream fileStream = File.Create(Path.Combine(savePath, fileExtensionName)))
            {
                fileStream.Write(fileBytes, 0, bytesRead);

                while (bytesRead == fileBytes.Length)
                {
                    bytesRead = stream.Read(fileBytes, 0, fileBytes.Length);
                    fileStream.Write(fileBytes, 0, bytesRead);
                }
            }
        }

        public void SendMsg(string msg)
        {
            byte[] msgBytes = msg.GetBytes();
            SendMsgByBytes(msgBytes);
        }

        private void SendMsgByBytes(byte[] msgBytes)
        {
            var stream = _tcpClient.GetStream();

            if (stream.CanWrite)
            {
                stream.Write(msgBytes, 0, msgBytes.Length);
            }
        }

        public bool SendFile(IFileService fileService, string fileName)
        {
            try
            {
                var targetFile = fileService.GetFilePath(fileName);

                if (targetFile == null)
                {
                    SendMsg(MsgType.Fail);
                    SendMsg($"Can not find file {fileName}");
                    return false;
                }

                // 傳送成功訊息
                SendMsg(MsgType.Success);

                // 傳送檔案包含附檔名
                string fileExtensionName = Path.GetFileName(targetFile);
                SendMsg(fileExtensionName);

                // 讀取檔案內容、傳送檔案內容
                var fileContentBytes = File.ReadAllBytes(targetFile);
                SendMsgByBytes(fileContentBytes);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public void Close()
        {
            _tcpClient.Close();
        }

        public void Dispose()
        {
            _tcpClient.Dispose();
        }
    }
}
