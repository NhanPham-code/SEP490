using FavoriteAPI.DTOs;
using FavoriteAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FavoriteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        // 2. Property tiện ích để lấy UserId, tránh lặp code
        private int? CurrentUserId =>
            int.TryParse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out var id) ? id : null;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService ?? throw new ArgumentNullException(nameof(favoriteService));
        }

        // 3. Sửa lại Get để chỉ lấy favorite của người dùng hiện tại
        [HttpGet]
        public async Task<IActionResult> GetUserFavoritesByAccessToken()
        {
            var userId = CurrentUserId;
            if (userId == null)
            {
                return Unauthorized(new { message = "Invalid user identity." });
            }

            var favorites = await _favoriteService.GetFavoritesByUserIdAsync(userId.Value);
            return Ok(favorites);
        }

        [HttpGet("exists")]
        public async Task<IActionResult> CheckIfFavoriteExists(int userId, int stadiumId)
        {
            // 1. Xác thực quyền: người dùng chỉ được kiểm tra cho chính họ
            var currentUserId = CurrentUserId;
            if (currentUserId == null || currentUserId.Value != userId)
            {
                return Forbid(); // Người dùng đã đăng nhập nhưng không có quyền
            }

            // 2. Gọi service để kiểm tra
            var isExists = await _favoriteService.IsFavoriteExistsAsync(userId, stadiumId);

            // 3. Trả về kết quả theo chuẩn REST
            if (isExists)
            {
                return Ok(); // 200 OK - Có tồn tại
            }

            return NotFound(); // 404 Not Found - Không tồn tại
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] CreateFavoriteDTO createFavoriteDTO)
        {
            if (createFavoriteDTO == null)
            {
                return BadRequest("Favorite data is null.");
            }

            var userId = CurrentUserId;
            if (userId == null)
            {
                return Unauthorized(new { message = "Invalid user identity." });
            }

            // 4. So sánh userId trong DTO với userId từ token
            if (createFavoriteDTO.UserId != userId.Value)
            {
                // 403 Forbidden là phù hợp hơn, vì người dùng đã được xác thực nhưng không có quyền thực hiện hành động này.
                return Forbid();
            }

            var isExists = await _favoriteService.IsFavoriteExistsAsync(createFavoriteDTO.UserId, createFavoriteDTO.StadiumId);
            if (isExists)
            {
                return Conflict("Favorite already exists.");
            }

            var favorite = await _favoriteService.AddFavoriteAsync(createFavoriteDTO);

            // Trả về route để lấy một favorite cụ thể sẽ tốt hơn là get list
            // Bạn cần có một phương thức GetFavoriteById(int id) để route này hoạt động
            return CreatedAtAction(nameof(GetUserFavoritesByAccessToken), new { id = favorite.FavoriteId }, favorite);
        }

        [HttpDelete("{userId}/{stadiumId}")]
        public async Task<IActionResult> DeleteFavorite(int userId, int stadiumId)
        {
            var currentUserId = CurrentUserId;
            if (currentUserId == null)
            {
                return Unauthorized(new { message = "Invalid user identity." });
            }

            // Security check - chỉ cho phép người dùng xóa favorites của chính họ
            if (userId != currentUserId.Value)
            {
                return Forbid();
            }

            // Kiểm tra favorite có tồn tại không
            var exists = await _favoriteService.IsFavoriteExistsAsync(userId, stadiumId);
            if (!exists)
            {
                return NotFound("Favorite not found.");
            }

            var isDeleted = await _favoriteService.DeleteFavoriteAsync(userId, stadiumId);
            if (!isDeleted)
            {
                return StatusCode(500, "Failed to delete favorite.");
            }
            return NoContent();
        }
    }
}
