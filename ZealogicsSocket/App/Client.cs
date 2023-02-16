using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ZealogicsSocket.Interfaces;
using ZealogicsSocket.Utils;

namespace ZealogicsSocket.App
{
    public class Client : IClient
    {
        public string DownloadFile(string ip, string port, string fileName, string savePath)
        {
            string result = string.Empty;

            try
            {
                TcpClient client = new TcpClient();
                client.Connect(ip, Convert.ToInt32(port));

                result += "已連線到server..." + Environment.NewLine;

                byte[] fileNameBytes = Encoding.ASCII.GetBytes(fileName);

                using (NetworkStream stream = client.GetStream())
                {
                    stream.Write(fileNameBytes, 0, fileNameBytes.Length);
                    result += $"要求下載檔案 { fileName }..." + Environment.NewLine;

                    string type = receiveMsg(stream);
                    result += type + Environment.NewLine;

                    if (type == MsgType.Success)
                    {
                        string fileExtensionName = receiveMsg(stream);

                        receiveFile(stream, savePath, fileExtensionName);
                    }
                    else if (type == MsgType.Fail)
                    {
                        string errorMsg = receiveMsg(stream);
                        result += errorMsg;
                    }

                }
                client.Close();
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }

        private string receiveMsg(Stream stream)
        {
            var bytes = new byte[1024];
            int bytesRead = stream.Read(bytes, 0, bytes.Length);
            string result = Encoding.ASCII.GetString(bytes, 0, bytesRead);
            return result;
        }

        private void receiveFile(Stream stream, string savePath, string fileExtensionName)
        {
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            var fileBytes = new byte[1024];
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
    }
}
