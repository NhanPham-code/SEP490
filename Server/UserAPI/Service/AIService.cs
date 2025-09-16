using System.Net.Http.Headers;
using System.Text.Json;
using UserAPI.DTOs;
using UserAPI.Service.Interface;

namespace UserAPI.Service
{
    public class AIService : IAiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AIService> _logger; // Thêm trường logger

        // Tiêm ILogger vào constructor
        public AIService(HttpClient httpClient, ILogger<AIService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); // Gán logger
        }

        public async Task<AiResponseModel?> ExtractInfoFromFrontCCCDImage(IFormFile frontCCCDImage)
        {
            if (frontCCCDImage == null || frontCCCDImage.Length == 0)
            {
                throw new ArgumentException("Ảnh CCCD không hợp lệ.", nameof(frontCCCDImage));
            }

            // Log khi bắt đầu
            _logger.LogInformation("Bắt đầu quá trình trích xuất thông tin từ ảnh: {FileName}, Kích thước: {Size} bytes.", frontCCCDImage.FileName, frontCCCDImage.Length);

            using var content = new MultipartFormDataContent();
            using var stream = frontCCCDImage.OpenReadStream();
            using var fileContent = new StreamContent(stream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(frontCCCDImage.ContentType);
            content.Add(fileContent, "image", frontCCCDImage.FileName); // "image" phải khớp với tên trường mà AI service mong đợi

            try
            {
                _logger.LogInformation("Đang gửi yêu cầu đến AI service tại địa chỉ: {BaseAddress}", _httpClient.BaseAddress);
                var response = await _httpClient.PostAsync("", content);

                var responseBody = await response.Content.ReadAsStringAsync();

                // Nếu response không thành công, ghi log lỗi và ném ra ngoại lệ
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("AI service trả về lỗi. Status Code: {StatusCode}. Response Body: {ResponseBody}", response.StatusCode, responseBody);
                    // Ném ra ngoại lệ sau khi đã ghi log
                    response.EnsureSuccessStatusCode();
                }

                _logger.LogDebug("Response Body từ AI: {ResponseBody}", responseBody);

                var aiResponse = JsonSerializer.Deserialize<AiResponseModel>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (aiResponse == null)
                {
                    _logger.LogWarning("Deserialize phản hồi từ AI service thành null. Response Body: {ResponseBody}", responseBody);
                    throw new JsonException("Không thể chuyển đổi phản hồi từ AI service.");
                }

                if (aiResponse.Id == null || aiResponse.Id.Count == 0 || string.IsNullOrWhiteSpace(aiResponse.Id.FirstOrDefault()))
                {
                    _logger.LogWarning("AI service trả về JSON hợp lệ nhưng không chứa dữ liệu CCCD. Đây có thể là ảnh không hợp lệ. Response Body: {ResponseBody}", responseBody);
                    return null; // Trả về null
                }

                // (Tùy chọn) Ghi log khi deserialize thành công ở cấp độ Debug để không làm spam log production
                _logger.LogInformation("Trích xuất dữ liệu từ CCCD thành công. Số CCCD: {CccdId}", aiResponse.Id.First());

                return aiResponse;
            }
            catch (Exception ex)
            {
                // Các lỗi hệ thống khác vẫn sẽ được ném ra bình thường
                _logger.LogError(ex, "Đã có lỗi không mong muốn xảy ra trong AIService.");
                throw;
            }
        }
    }
}
