using FileDownloaderApi.Controllers;
using FileDownloaderApi.Models;
using FileDownloaderApi.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDownloaderApi.Tests.Controllers
{
    [TestFixture]
    internal class FileDownloadControllerTest
    {

        [Test]
        public void GetFile_ReturnsFile()
        {
            //arrange
            var fname = "textfile.txt";
            var testStream = new MemoryStream(Encoding.UTF8.GetBytes("whatever"));


            var mockedFileModel = new FileModel()
            {
                Filename = fname,
                Directory = "",
                FileMimeType = "plain/text",
                Filestream = testStream
                
            };

            var filedownloader = new Mock<IFileDownloader>();
            filedownloader.Setup(x => x.Run(null)).ReturnsAsync(mockedFileModel);

            FileDownloadController controller = new FileDownloadController(filedownloader.Object);

            //act
            var actualResult=controller.GetFile();


            //assert
            Assert.That(actualResult.Result, Is.Not.Null);
            Assert.IsInstanceOf<FileStreamResult>(actualResult.Result);


        }

        [Test]
        public async Task GetFile_ReturnsNull()
        {
            //arrange
            FileModel mockedFileModel = null;

            var filedownloader = new Mock<IFileDownloader>();
            filedownloader.Setup(x => x.Run(null)).ReturnsAsync(mockedFileModel);

            FileDownloadController controller = new FileDownloadController(filedownloader.Object);

            //act
            var actualResult = await controller.GetFile();


            //assert
            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOf<NotFoundResult>(actualResult);  //method 1 of checking type
            Assert.IsTrue(actualResult is NotFoundResult);      //method 2 of checking type (both achieve same objective)
            



        }

    }
}
