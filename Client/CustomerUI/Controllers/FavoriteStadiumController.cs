using DTOs.FavoriteStadiumDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Security.Claims;

namespace CustomerUI.Controllers
{
    public class FavoriteStadiumController : Controller
    {
        private readonly IFavoriteStadiumService _favoriteStadiumService;
        private readonly ITokenService _tokenService;

        public FavoriteStadiumController(IFavoriteStadiumService favoriteStadiumService, ITokenService tokenService)
        {
            _favoriteStadiumService = favoriteStadiumService;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Lấy Access Token từ session của người dùng đã đăng nhập.
        /// </summary>
        private string? GetAccessToken()
        {
            // Lấy token từ session với key "AccessToken"
            return _tokenService.GetAccessTokenFromCookie();
        }

        /// <summary>
        /// Lấy UserId từ Session của người dùng đã đăng nhập.
        /// </summary>
        private int? GetCurrentUserId()
        {
            // *** ĐÃ THAY ĐỔI THEO YÊU CẦU ***
            // Lấy UserId từ Session. 
            // Giả sử bạn lưu nó với key là "UserId" và kiểu là int.
            return HttpContext?.Session.GetInt32("UserId");
        }

        /// <summary>
        /// Endpoint để thêm một sân vận động vào danh sách yêu thích.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] CreateFavoriteDTO createDto)
        {
            var token = GetAccessToken();
            var userId = GetCurrentUserId(); // Phương thức này giờ sẽ lấy từ Session

            if (string.IsNullOrEmpty(token) || userId == null)
            {
                return Unauthorized(new { message = "Vui lòng đăng nhập để thực hiện chức năng này." });
            }

            createDto.UserId = userId.Value;

            try
            {
                var result = await _favoriteStadiumService.AddFavoriteAsync(createDto, token);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (sử dụng một logger thực tế)
                Console.WriteLine($"Error in AddFavorite: {ex.Message}");
                return BadRequest(new { message = "Đã có lỗi xảy ra. Sân này có thể đã có trong danh sách yêu thích của bạn." });
            }
        }

        /// <summary>
        /// Endpoint để xóa một sân vận động khỏi danh sách yêu thích.
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteFavorite(int stadiumId)
        {
            var token = GetAccessToken();
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { message = "Vui lòng đăng nhập." });
            }

            var userId = GetCurrentUserId();

            try
            {
                var isSuccess = await _favoriteStadiumService.DeleteFavoriteAsync(userId.Value, stadiumId, token);
                if (isSuccess)
                {
                    return Ok(new { message = "Đã xóa khỏi danh sách yêu thích." });
                }
                return NotFound(new { message = "Không tìm thấy mục yêu thích để xóa." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteFavorite: {ex.Message}");
                return BadRequest(new { message = "Đã có lỗi xảy ra khi xóa." });
            }
        }

        /// <summary>
        /// Endpoint để lấy danh sách các sân vận động yêu thích của người dùng hiện tại.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetMyFavorites()
        {
            var token = GetAccessToken();
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new { message = "Vui lòng đăng nhập để xem danh sách yêu thích." });
            }

            try
            {
                var jsonResult = await _favoriteStadiumService.GetMyFavoritesForUIAsync(token);
                // Trả về Content với kiểu "application/json"
                return Content(jsonResult, "application/json");
            }
            catch (System.Exception)
            {
                // Service đã log lỗi, ở đây chỉ cần trả về lỗi cho client
                return StatusCode(500, "An internal server error occurred.");
            }
        }
    }
}