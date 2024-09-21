using FileDownloaderApi.Services;

namespace FileDownloaderApi.Models
{
    public interface IFileDownloader
    {
        Task<FileModel?> Run(string? filename);
    }


    public class FileDownloader:IFileDownloader
    {

        private readonly IFileService _fileService;
        //private readonly string resourcesDirectory = Directory.GetCurrentDirectory() + "\\Resources\\";

        public FileDownloader(IFileService fileService)
        {
                _fileService = fileService;
        }


        public async Task<FileModel?> Run(string? filename)
        {
            var resourcesDirectory = Directory.GetCurrentDirectory() + "\\Resources\\";
            if (string.IsNullOrEmpty(filename))
                filename= "dark_blue_gry.JPG";

            //var filemodel=GetFileModel(filename);

            FileModel filemodel = new(filename, resourcesDirectory);

            var filestream = await _fileService.GetFileAsStream(filemodel);

            if (filestream.Length > 0)
            {
                filemodel.Filestream = filestream;
                return filemodel;
            }
 
            return null;
        }

        //private FileModel GetFileModel(string filename)
        //{
        //    FileModel filemodel = new(filename,resourcesDirectory);
        //    return filemodel;

        //}
    }
}
