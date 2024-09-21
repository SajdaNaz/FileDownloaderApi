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
    internal class FileDownloaderTest
    {

        [Test]
        public async Task Run_WhenExecuted_ReturnsNotNull()
        {
            //arrange
            var fname = "textfile.txt";
            
            var mockedFileModel = new FileModel()
            {
                Filename = fname,
                Directory = "",
                FileMimeType = "plain/text"
            };

            var testStream = new MemoryStream(Encoding.UTF8.GetBytes("whatever"));

            var fileservice = new Mock<IFileService>();
            fileservice.Setup(x => x.GetFileAsStream(It.IsAny<FileModel>())).ReturnsAsync(testStream);

            var filemodel=new Mock<IFileModel>();
            filemodel.Setup(x => x.NewFrom(It.IsAny<string>(),It.IsAny<string>())).Returns(mockedFileModel);

            FileDownloader fileDownloader = new FileDownloader(fileservice.Object, filemodel.Object);


            //act
            var actualResult = fileDownloader.Run(fname);


            //assert
            Assert.That(actualResult.Result, Is.Not.Null);
            Assert.That(actualResult.Result.Filestream, Is.Not.Null);


        }

        [Test]
        public async Task Run_WhenExecuted_ReturnsNull()
        {
            //arrange
            var fname = "textfile.txt";

            var mockedFileModel = new FileModel()
            {
                Filename = fname,
                Directory = "",
                FileMimeType = "plain/text"
            };

            var testStream = new MemoryStream();

            var fileservice = new Mock<IFileService>();
            fileservice.Setup(x => x.GetFileAsStream(It.IsAny<FileModel>())).ReturnsAsync(testStream);

            var filemodel = new Mock<IFileModel>();
            filemodel.Setup(x => x.NewFrom(It.IsAny<string>(), It.IsAny<string>())).Returns(mockedFileModel);

            FileDownloader fileDownloader = new FileDownloader(fileservice.Object, filemodel.Object);


            //act
            var actualResult = fileDownloader.Run(fname);


            //assert
            Assert.That(actualResult.Result, Is.Null);

        }


    }
}




