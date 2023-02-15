using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealogicsSocket.Interface
{
    internal interface IClient
    {
        string DownloadFile(string ip, string port, string fileName, string savePath);
    }
}
