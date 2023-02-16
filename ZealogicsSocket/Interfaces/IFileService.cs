using System;
using System.Collections.Generic;

namespace ZealogicsSocket.Interfaces
{
    public interface IFileService
    {
        IEnumerable<string> GetFiles();

        string GetFilePath(string target);
    }
}
