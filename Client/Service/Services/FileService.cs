using Microsoft.AspNetCore.Http;
using Service.BaseService;
using Service.Interfaces;
using System.Net.Http.Headers;

namespace Service.Services
{
    public class FileService : IFileService
    {
        private readonly HttpClient _httpClient;
        private readonly long _maxFileSize = 5 * 1024 * 1024; // 5MB
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

        public FileService(GatewayHttpClient gateway)
        {
            _httpClient = gateway.Client;
        }

        private void AddBearerAccessToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<string?> UploadImageAsync(IFormFile file, string folderName, string accessToken)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty");

            if (!IsValidImageFile(file))
                throw new ArgumentException("Invalid file type or size");

            AddBearerAccessToken(accessToken);

            using var formData = new MultipartFormDataContent();

            var fileContent = new StreamContent(file.OpenReadStream());
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            formData.Add(fileContent, "file", file.FileName);
            formData.Add(new StringContent(folderName), "folderName");

            var response = await _httpClient.PostAsync("api/files/upload", formData);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[FileService] UploadImageAsync failed: {response.StatusCode} - {errorMessage}");
                return null;
            }

            var result = await response.Content.ReadAsStringAsync();
            return result.Trim('"'); // Remove quotes if present
        }

        public async Task<bool> DeleteImageAsync(string imagePath, string accessToken)
        {
            if (string.IsNullOrEmpty(imagePath))
                return false;

            AddBearerAccessToken(accessToken);

            var response = await _httpClient.DeleteAsync($"api/files/delete?imagePath={Uri.EscapeDataString(imagePath)}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[FileService] DeleteImageAsync failed: {response.StatusCode}");
                return false;
            }

            return true;
        }

        public async Task<byte[]?> DownloadImageAsync(string imagePath, string accessToken)
        {
            if (string.IsNullOrEmpty(imagePath))
                return null;

            AddBearerAccessToken(accessToken);

            var response = await _httpClient.GetAsync($"api/files/download?imagePath={Uri.EscapeDataString(imagePath)}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[FileService] DownloadImageAsync failed: {response.StatusCode}");
                return null;
            }

            return await response.Content.ReadAsByteArrayAsync();
        }

        public bool IsValidImageFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            // Kiểm tra size
            if (file.Length > _maxFileSize)
                return false;

            // Kiểm tra extension
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(extension))
                return false;

            // Kiểm tra content type
            var allowedMimeTypes = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif", "image/bmp" };
            if (!allowedMimeTypes.Contains(file.ContentType.ToLowerInvariant()))
                return false;

            return true;
        }

        public string GetImageUrl(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return string.Empty;

            // Assuming your server base URL, adjust as needed
            var baseUrl = _httpClient.BaseAddress?.ToString().TrimEnd('/');
            return $"{baseUrl}{imagePath}";
        }
    }
}