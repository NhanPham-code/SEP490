using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using DTOs.StadiumDTO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml; // Thêm using cho XmlConvert

namespace CustomerUI.Controllers
{
    // SỬ DỤNG CONVERTER MỚI BẠN CUNG CẤP
    // Converter này có thể xử lý đúng định dạng ISO 8601 Duration (ví dụ: "PT6H")
    public class Iso8601TimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException($"Unexpected token type {reader.TokenType}. Expected a string.");
            }
            string value = reader.GetString();
            // XmlConvert có thể parse chính xác định dạng ISO 8601 duration
            return string.IsNullOrEmpty(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            // Ghi lại TimeSpan dưới dạng chuỗi ISO 8601 duration
            writer.WriteStringValue(XmlConvert.ToString(value));
        }
    }


    public class StadiumController : Controller
    {
        private readonly IStadiumService _stadiumService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;   // ✅ thêm UserService

        public StadiumController(IStadiumService stadiumService, ITokenService tokenService, IUserService userService)
        {
            _stadiumService = stadiumService;
            _tokenService = tokenService;
            _userService = userService;
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

            // ✅ Lấy user profile từ token
            var accessToken = GetAccessToken();
            var profile = string.IsNullOrEmpty(accessToken)
                ? null
                : await _userService.GetMyProfileAsync(accessToken);

            ViewBag.UserId = profile?.UserId;
            ViewBag.UserName = profile?.FullName ?? "User";
            ViewBag.Profile = profile;

            // ✅ Load stadium info
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

            return View("StadiumDetail", stadium);
        }
    }
}