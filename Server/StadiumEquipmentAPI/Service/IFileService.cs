namespace StadiumEquipmentAPI.Service
{
    public interface IFileService
    {
        Task<string> UploadImageAsync(IFormFile file, string folderName);
        Task<bool> DeleteImageAsync(string imagePath);
        bool IsValidImageFile(IFormFile file);
    }
}