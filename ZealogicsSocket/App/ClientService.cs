using System;
using ZealogicsSocket.Interfaces;
using ZealogicsSocket.Utils;

namespace ZealogicsSocket.App
{
    public class ClientService
    {
        private ITcpClient _client;
        private string _ip { get; }
        private string _port { get; }

        public ClientService(ITcpClient client, string ip, string port)
        {
            _client = client;
            _ip = ip;
            _port = port;
        }

        public string DownloadFile(string fileName, string savePath)
        {
            string result = string.Empty;

            try
            {
                _client.Connect(_ip, Convert.ToInt32(_port));
                result += "已連線到server..." + Environment.NewLine;

                _client.SendMsg(fileName);
                result += $"要求下載檔案 {fileName}..." + Environment.NewLine;

                string type = _client.ReceiveMsg();
                result += type + Environment.NewLine;

                if (type == MsgType.Success)
                {
                    string fileExtensionName = _client.ReceiveMsg();
                    _client.ReceiveFile(savePath, fileExtensionName);
                }
                else if (type == MsgType.Fail)
                {
                    string errorMsg = _client.ReceiveMsg();
                    result += errorMsg;
                }

                _client.Close();
            }
            catch (Exception e)
            {
                result = e.Message;
            }

            return result;
        }
    }
}
