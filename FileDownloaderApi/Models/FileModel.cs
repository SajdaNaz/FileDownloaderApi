using Microsoft.AspNetCore.StaticFiles;
using System.IO;

namespace FileDownloaderApi.Models
{

    public interface IFileModel
    {
        FileModel NewFrom(string filename, string directory);
    }

    public class FileModel:IFileModel
    {
        public string Filename { get; set; } = string.Empty;
        public string Directory { get; set; } = string.Empty;
        public string FileMimeType { get; set; } = string.Empty;
        public Stream Filestream { get; set; } 


        public FileModel NewFrom(string filename, string directory)
        {
            return new FileModel()
            {
                Filename = filename,
                Directory = directory,
                FileMimeType = SetFileMimeType(filename)
            };

        }

        private static string SetFileMimeType(string filename)
        {
            var provider = new FileExtensionContentTypeProvider();

            var extension = "." + filename.Split('.').Last();

            if (provider.TryGetContentType(extension, out string? mimetype))
                return mimetype;

            return "text/plain";
        }



    }
}