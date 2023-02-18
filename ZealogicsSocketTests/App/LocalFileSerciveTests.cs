using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ZealogicsSocket.Interfaces;


namespace ZealogicsSocket.App.Tests
{
    [TestClass()]
    public class LocalFileSerciveTests
    {
        [TestMethod()]
        public void GetFilePathTest()
        {
            IFileService localFileSercive = new LocalFileSercive();

            string existFileName = "test01";

            var exist = localFileSercive.GetFilePath(existFileName);
            var notExist = localFileSercive.GetFilePath("test99");

            Assert.AreEqual(Path.GetFileNameWithoutExtension(exist), existFileName);
            Assert.IsNull(notExist);
        }
    }
}