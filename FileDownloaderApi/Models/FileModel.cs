using Microsoft.AspNetCore.StaticFiles;

namespace FileDownloaderApi.Models
{
    public class FileModel
    {
        public string Filename { get; set; } = string.Empty;
        public string Directory { get; set; } = string.Empty;
        public string FileMimeType { get; set; }=string.Empty;
        public Stream? Filestream { get; set; }

        //public FileModel()
        //{

        //}

        public FileModel(string filename, string directory)
        {
            Filename = filename;
            Directory = directory;
            FileMimeType = SetFileMimeType(filename);
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