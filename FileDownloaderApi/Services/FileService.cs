using FileDownloaderApi.Models;

namespace FileDownloaderApi.Services
{
    public interface IFileService
    {
        public Task<Stream> GetFileAsStream(FileModel filemodel);
        public Task<byte[]> GetFileAsByteArray(FileModel filemodel);

    }

    public class FileService:IFileService
    {
        public async Task<Stream> GetFileAsStream(FileModel filemodel) => new MemoryStream(await ConvertFileToByteArray(filemodel));

        public async Task<byte[]> GetFileAsByteArray(FileModel filemodel) => await ConvertFileToByteArray(filemodel);

        private static async Task<byte[]> ConvertFileToByteArray(FileModel filemodel)
        {

            try
            {
                var path = Path.Combine(filemodel.Directory, filemodel.Filename);

                return await File.ReadAllBytesAsync(path);
            }
            catch (Exception ex)
            {
                return [];
            }

        }

    }
}