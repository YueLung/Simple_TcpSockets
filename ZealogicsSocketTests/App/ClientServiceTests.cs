using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using Moq;
using ZealogicsSocket.Interfaces;


namespace ZealogicsSocket.App.Tests
{
    [TestClass()]
    public class ClientServiceTests
    {
        [TestMethod()]
        public void Download_NotExist_FileTest()
        {
            //Arrange 
            ITcpClient clientMock = new TcpClientAdapter();
            var fileServicMock = new Mock<IFileService>();

            fileServicMock.Setup(c => c.GetFilePath("NotExistFileName"))
                .Returns(null as string);

            //Act
            bool result = clientMock.SendFile(fileServicMock.Object, "NotExistFileName");
   
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void SendMsgTest()
        {
            //Arrange
            var clientMock = new Mock<ITcpClient>();
            var serverMock = new Mock<ITcpListener>();

            clientMock.Setup(c => c.GetStream())
                .Returns(new MemoryStream(Encoding.ASCII.GetBytes("Hello, World!")));

            serverMock.Setup(s => s.AcceptTcpClient())
                .Returns(clientMock.Object);

            //Act
            serverMock.Object.Start(result => { });
            var client = serverMock.Object.AcceptTcpClient();
            var stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            client.Close();
            serverMock.Object.Stop();

            //Assert
            Assert.AreEqual("Hello, World!", message);
        }
    }
}