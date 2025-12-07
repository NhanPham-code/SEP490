using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using DTOs.StadiumDTO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace CustomerUI.Controllers
{
    // Custom Converter để parse TimeSpan từ chuỗi ISO 8601 (VD: "PT6H")
    public class Iso8601TimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException($"Unexpected token type {reader.TokenType}. Expected a string.");
            }
            string value = reader.GetString();
            return string.IsNullOrEmpty(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(XmlConvert.ToString(value));
        }
    }

    public class StadiumController : Controller
    {
        private readonly IStadiumService _stadiumService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IStadiumVideoSetvice _stadiumVideoService; // 1. Inject Service Video

        // Constant cho Video Base URL
        private const string VideoBaseUrl = "https://localhost:7280/";

        public StadiumController(
            IStadiumService stadiumService,
            ITokenService tokenService,
            IUserService userService,
            IStadiumVideoSetvice stadiumVideoService) // Inject vào Constructor
        {
            _stadiumService = stadiumService;
            _tokenService = tokenService;
            _userService = userService;
            _stadiumVideoService = stadiumVideoService;
        }

        private string? GetAccessToken()
        {
            return Request.Cookies["AccessToken"];
        }

        public async Task<IActionResult> StadiumDetail(int stadiumId)
        {
            if (stadiumId <= 0)
            {
                return RedirectToAction("Index", "Home");
            }

            // --- Lấy thông tin User ---
            var accessToken = GetAccessToken();
            var profile = string.IsNullOrEmpty(accessToken)
                ? null
                : await _userService.GetMyProfileAsync(accessToken);

            ViewBag.UserId = profile?.UserId;
            ViewBag.UserName = profile?.FullName ?? "User";
            ViewBag.Profile = profile;

            // --- Lấy thông tin Sân vận động ---
            var searchTerm = $"&$filter=Id eq {stadiumId}";
            var odataResponse = await _stadiumService.SearchStadiumAsync(searchTerm);

            if (string.IsNullOrEmpty(odataResponse))
            {
                return NotFound();
            }

            ReadStadiumDTO stadium = null;
            try
            {
                using (var jsonDoc = JsonDocument.Parse(odataResponse))
                {
                    var firstStadiumElement = jsonDoc.RootElement.GetProperty("value").EnumerateArray().FirstOrDefault();
                    if (firstStadiumElement.ValueKind != JsonValueKind.Undefined)
                    {
                        string stadiumJson = firstStadiumElement.GetRawText();

                        var serializerOptions = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                            Converters = { new Iso8601TimeSpanConverter() }
                        };

                        stadium = JsonSerializer.Deserialize<ReadStadiumDTO>(stadiumJson, serializerOptions);
                    }
                }
            }
            catch
            {
                return View("Error");
            }

            if (stadium == null)
            {
                return NotFound();
            }

            // --- 2. Lấy danh sách Video & Xử lý URL ---
            try
            {
                var videos = await _stadiumVideoService.GetAllVideoByStadiumId(stadiumId);

                // 3. Xử lý nối chuỗi URL cho video
                // Lưu ý: Kiểm tra null để tránh lỗi nếu videoUrl rỗng
                foreach (var video in videos)
                {
                    if (!string.IsNullOrEmpty(video.VideoUrl) && !video.VideoUrl.StartsWith("http"))
                    {
                        video.VideoUrl = VideoBaseUrl + video.VideoUrl;
                    }
                }

                // 4. Truyền sang View qua ViewBag (hoặc bạn có thể tạo ViewModel bao gồm cả Stadium và Videos)
                ViewBag.StadiumVideos = videos;
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần, nhưng không được để lỗi video làm crash trang chi tiết sân
                Console.WriteLine($"Lỗi lấy video sân vận động: {ex.Message}");
                ViewBag.StadiumVideos = new List<ReadStadiumVideoDTO>();
            }

            return View("StadiumDetail", stadium);
        }
    }
}