using Microsoft.AspNetCore.Http;

namespace Service.Interfaces
{
    public interface IFileService
    {
        Task<string?> UploadImageAsync(IFormFile file, string folderName, string accessToken);
        Task<bool> DeleteImageAsync(string imagePath, string accessToken);
        Task<byte[]?> DownloadImageAsync(string imagePath, string accessToken);
        bool IsValidImageFile(IFormFile file);
        string GetImageUrl(string imagePath);
    }
}