using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using ZealogicsSocket.Interfaces;

namespace ZealogicsSocket.App
{
    public class LocalFileService : IFileService
    {
        public IEnumerable<string> GetFiles()
        {
            string fileDir = Path.Combine(Directory.GetCurrentDirectory(), "File");
            var files = Directory.GetFiles(fileDir);

            return files;
        }

        public string GetFilePath(string target) => GetFiles().Where(f => Path.GetFileNameWithoutExtension(f).Equals(target)).FirstOrDefault();
    }
}
