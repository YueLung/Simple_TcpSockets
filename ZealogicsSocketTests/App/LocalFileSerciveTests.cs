using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZealogicsSocket.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZealogicsSocket.App.Tests
{
    [TestClass()]
    public class LocalFileSerciveTests
    {
        [TestMethod()]
        public void GetFilePathTest()
        {
            LocalFileSercive localFileSercive = new LocalFileSercive();

            string existFileName = "test01";

            var result_exist = localFileSercive.GetFilePath(existFileName);
            var result_notExist = localFileSercive.GetFilePath("test99");

            Assert.AreEqual(Path.GetFileNameWithoutExtension(result_exist), existFileName);
            Assert.IsNull(result_notExist);
        }
    }
}