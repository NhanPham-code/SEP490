using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs.DiscountDTO;
using DTOs.StadiumDTO;
using System;
using System.Text.Json;
using StadiumManagerUI.Helpers;
using Microsoft.AspNetCore.Http;

namespace CustomerUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IStadiumService _stadiumService;
        private readonly IFavoriteStadiumService _favoriteStadiumService;
        private readonly ITokenService _tokenService;

        private const int PageSize = 5;

        public DiscountController(
            IDiscountService discountService,
            IStadiumService stadiumService,
            IFavoriteStadiumService favoriteStadiumService,
            ITokenService tokenService)
        {
            _discountService = discountService;
            _stadiumService = stadiumService;
            _favoriteStadiumService = favoriteStadiumService;
            _tokenService = tokenService;
        }

        public IActionResult DiscountList()
        {
            return View();
        }

        /// <summary>
        /// Lấy mã giảm giá cá nhân (Unique type) - Server-side pagination
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetPersonalDiscounts(int page = 1)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            var userId = HttpContext.Session.GetInt32("UserId");

            if (string.IsNullOrEmpty(accessToken) || userId == null)
            {
                return Unauthorized(new { message = "Phiên đăng nhập hết hạn hoặc không hợp lệ." });
            }

            // ✅ Dùng hàm mới GetDiscountsAsync
            var response = await _discountService.GetDiscountsAsync(
                accessToken,
                targetUserId: userId.Value.ToString(),
                page: page,
                pageSize: PageSize,
                isActive: true,
                filterExpired: true,
                orderBy: "CreatedAt desc"
            );

            if (response == null || response.Value == null || !response.Value.Any())
            {
                return Json(new
                {
                    discounts = new List<ReadDiscountDTO>(),
                    stadiums = new List<ReadStadiumDTO>(),
                    count = 0,
                    page,
                    pageSize = PageSize
                });
            }

            var stadiums = await GetStadiumsInfo(response.Value);

            return Json(new
            {
                discounts = response.Value,
                stadiums,
                count = response.Count ?? 0,
                page,
                pageSize = PageSize
            });
        }

        /// <summary>
        /// Lấy mã giảm giá từ các sân yêu thích (Stadium type) - Server-side pagination
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetFavoriteStadiumDiscounts(int page = 1)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();

            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Phiên đăng nhập hết hạn hoặc không hợp lệ." });
            }

            // Bước 1: Lấy danh sách sân yêu thích
            var favoriteStadiums = await _favoriteStadiumService.GetMyFavoritesAsync(accessToken);
            var favoriteStadiumIds = favoriteStadiums?
                .Select(f => f.StadiumId)
                .Distinct()
                .ToList() ?? new List<int>();

            // Nếu không có sân yêu thích nào
            if (!favoriteStadiumIds.Any())
            {
                return Json(new
                {
                    discounts = new List<ReadDiscountDTO>(),
                    stadiums = new List<ReadStadiumDTO>(),
                    count = 0,
                    page,
                    pageSize = PageSize
                });
            }

            // ✅ Dùng hàm mới GetDiscountsAsync
            var response = await _discountService.GetDiscountsAsync(
                accessToken,
                stadiumIds: favoriteStadiumIds,
                isPersonalDiscount: false,  // Chỉ lấy mã sân (TargetUserId == null)
                page: page,
                pageSize: PageSize,
                isActive: true,
                filterExpired: true,
                orderBy: "CreatedAt desc"
            );

            if (response == null || response.Value == null || !response.Value.Any())
            {
                return Json(new
                {
                    discounts = new List<ReadDiscountDTO>(),
                    stadiums = new List<ReadStadiumDTO>(),
                    count = 0,
                    page,
                    pageSize = PageSize
                });
            }

            var stadiums = await GetStadiumsInfo(response.Value);

            return Json(new
            {
                discounts = response.Value,
                stadiums,
                count = response.Count ?? 0,
                page,
                pageSize = PageSize
            });
        }

        /// <summary>
        /// Helper: Lấy thông tin các stadium từ danh sách discounts
        /// </summary>
        private async Task<List<ReadStadiumDTO>> GetStadiumsInfo(List<ReadDiscountDTO> discounts)
        {
            var stadiumIdsToFetch = discounts
                .Where(d => d.StadiumIds != null)
                .SelectMany(d => d.StadiumIds)
                .Distinct()
                .ToList();

            if (!stadiumIdsToFetch.Any())
            {
                return new List<ReadStadiumDTO>();
            }

            var stadiumsJson = await _stadiumService.SearchStadiumAsync("");

            if (string.IsNullOrEmpty(stadiumsJson))
            {
                return new List<ReadStadiumDTO>();
            }

            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                options.Converters.Add(new Iso8601TimeSpanConverter());

                using var doc = JsonDocument.Parse(stadiumsJson);

                if (doc.RootElement.TryGetProperty("value", out var valueElement))
                {
                    var allStadiums = JsonSerializer.Deserialize<List<ReadStadiumDTO>>(
                        valueElement.GetRawText(),
                        options
                    );

                    return allStadiums?
                        .Where(s => stadiumIdsToFetch.Contains(s.Id))
                        .ToList() ?? new List<ReadStadiumDTO>();
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"[ERROR] GetStadiumsInfo - JSON Parse Error: {ex.Message}");
            }

            return new List<ReadStadiumDTO>();
        }
    }
}