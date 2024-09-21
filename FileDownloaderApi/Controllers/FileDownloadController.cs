using FileDownloaderApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace FileDownloaderApi.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileDownloadController : ControllerBase
    {
        private readonly IFileDownloader _fileDownloader;

        public FileDownloadController(IFileDownloader fileDownloader)
        {
            _fileDownloader = fileDownloader;
        }

        [HttpGet(Name = "GetFile")]
        public async Task<IActionResult> GetFile()
        {
            var retVal = await _fileDownloader.Run(null);

            if (retVal == null)
                return NotFound();

            return File(retVal.Filestream, retVal.FileMimeType, retVal.Filename);

        }

        [HttpGet(template: "GetFile/{fname}",Name = "GetFileWithName")]
        public async Task<IActionResult> GetFile(string fname)
        {
            var retVal = await _fileDownloader.Run(fname);

            if (retVal == null)
                return NotFound();

            return File(retVal.Filestream, retVal.FileMimeType, retVal.Filename);

        }


        [HttpGet(template: "GetSummat", Name = "GetSummat")]
        public IActionResult GetSummat()
        {
            var retVal = 4444;

            return Ok(retVal);

        }
    }
}
