using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using UserAPI.DTOs;
using UserAPI.Service.Interface;

namespace UserAPI.Service
{
    public class AIService : IAiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AIService> _logger; // Thêm trường logger

        private readonly string CCCD_AI_SERVER_URL = "http://127.0.0.1:9999"; // URL của CCCD AI service
        private readonly string FACE_AI_SERVER_URL = "http://127.0.0.1:5000"; // URL của Face AI service
        private readonly string FACE_REGISTER_ENDPOINT = "/api/register"; // Endpoint để đăng ký khuôn mặt và nhận embeddings từ Face AI service
        private readonly string FACE_LOGIN_ENDPOINT = "/api/login_face"; // Endpoint để nhận diện khuôn mặt từ Face AI service

        // Tiêm ILogger vào constructor
        public AIService(HttpClient httpClient, ILogger<AIService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); // Gán logger
        }

        public async Task<AiCccdResponseModel?> ExtractInfoFromFrontCCCDImage(IFormFile frontCCCDImage)
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
                var response = await _httpClient.PostAsync(CCCD_AI_SERVER_URL, content); // Gửi yêu cầu đến CCCD AI service

                var responseBody = await response.Content.ReadAsStringAsync();

                // Nếu response không thành công, ghi log lỗi và ném ra ngoại lệ
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("AI service trả về lỗi. Status Code: {StatusCode}. Response Body: {ResponseBody}", response.StatusCode, responseBody);
                    response.EnsureSuccessStatusCode();
                }

                _logger.LogDebug("Response Body từ AI: {ResponseBody}", responseBody);

                var aiResponse = JsonSerializer.Deserialize<AiCccdResponseModel>(responseBody, new JsonSerializerOptions
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

                // Ghi log khi deserialize thành công ở cấp độ Debug để không làm spam log production
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

        public async Task<AiFaceLoginResponseModel?> LoginWithFaceAsync(IFormFile faceImage, IEnumerable<UserEmbeddingDTO> userEmbeddingDTOs)
        {
            if (faceImage == null || faceImage.Length == 0)
                throw new ArgumentException("Ảnh khuôn mặt không hợp lệ.", nameof(faceImage));
            if (userEmbeddingDTOs == null || !userEmbeddingDTOs.Any())
                throw new ArgumentException("Danh sách embedding không hợp lệ.", nameof(userEmbeddingDTOs));

            // Chuyển ảnh sang base64 string
            string base64Image;
            using (var ms = new MemoryStream())
            {
                await faceImage.CopyToAsync(ms);
                var bytes = ms.ToArray();
                base64Image = $"data:{faceImage.ContentType};base64,{Convert.ToBase64String(bytes)}";
            }

            // Build payload: image + list embedding
            var payload = new
            {
                image = base64Image,
                user_embeddings = userEmbeddingDTOs
            };

            // Serialize payload thành JSON
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            // Gửi POST sang AI server
            var url = "http://127.0.0.1:5000/api/login_face";
            using var response = await _httpClient.PostAsync(url, jsonContent);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Đăng nhập khuôn mặt thành công
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<AiFaceLoginResponseModel>(
                    responseBody,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
                return result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                // Khuôn mặt không khớp, trả về model thất bại
                return new AiFaceLoginResponseModel
                {
                    Success = false,
                    Message = "Xác thực khuôn mặt thất bại hoặc không khớp dữ liệu. \n Bạn hãy đăng nhập thủ công và cập nhật khuôn mặt tại hồ sơ cá nhân."
                };
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return new AiFaceLoginResponseModel
                {
                    Success = false,
                    Message = "Không nhận dạng được khuôn mặt. "
                };
            }
            else
            {
                // Các lỗi khác, có thể log lại nội dung trả về để debug
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"AI server trả về lỗi {response.StatusCode}: {error}");
            }
        }

        public async Task<AiFaceRegisterResponseModel?> RegisterFaceAsync(IEnumerable<IFormFile> faceImages, string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email không hợp lệ.", nameof(email));
            if (faceImages == null || !faceImages.Any()) throw new ArgumentException("Phải truyền ít nhất 1 ảnh.", nameof(faceImages));

            // Chuyển các ảnh sang base64 string
            var base64Images = new List<string>();
            foreach (var file in faceImages)
            {
                using var ms = new MemoryStream();
                await file.CopyToAsync(ms);
                var bytes = ms.ToArray();
                var base64String = $"data:{file.ContentType};base64,{Convert.ToBase64String(bytes)}";
                base64Images.Add(base64String);
            }

            // Build payload
            var payload = new
            {
                email = email,
                images = base64Images
            };

            // Serialize payload thành JSON
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            // Gửi POST sang AI server
            var url = "http://127.0.0.1:5000/api/register";
            using var response = await _httpClient.PostAsync(url, jsonContent);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                // Tùy chọn log lỗi và throw
                throw new Exception($"AI server trả về lỗi: {response.StatusCode} - {responseBody}");
            }

            // Deserialize kết quả
            var result = JsonSerializer.Deserialize<AiFaceRegisterResponseModel>(
                responseBody,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            return result;
        }
    }
}
