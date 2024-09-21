using Microsoft.VisualStudio.TestPlatform.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FileDownloaderApi.Services;
using FileDownloaderApi.Models;
using System.Runtime.Versioning;



namespace FileDownloaderApi.Tests.Models
{
    [TestFixture()]
    public class FileDownloaderTest
    {

        [Test]
        public async Task Run_WhenExecuted_ReturnsNull()
        {
            var fname = "textfile.txt";

            var testStream = new MemoryStream(Encoding.UTF8.GetBytes("whatever"));

            //var fileModel_mocked = new Mock<FileModel>("filename.txt","resourcesDirectory");
            var fileModel_mocked = new Mock<FileModel>(MockBehavior.Strict, "textfile.txt", "resources","img/jpg" );
            fileModel_mocked.Setup(x => x.)
            var fileModel = fileModel_mocked.Object;

            var fileservice = new Mock<IFileService>();
            fileservice.Setup(x => x.GetFileAsStream(It.IsAny<FileModel>())).ReturnsAsync(testStream);

            FileDownloader fileDownloader = new FileDownloader(fileservice.Object);

            var actualResult=fileDownloader.Run(fname);

            Assert.That(actualResult.Result.Filename, Is.Not.Null);

            //Act
            //using (var test_Stream = new MemoryStream(Encoding.UTF8.GetBytes("whatever")))
            //{
            //    var result = imp.Import(test_Stream);

            //    // Assert    
            //    Assert.IsTrue(result);
            //}

        }


    }
}




