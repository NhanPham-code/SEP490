using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DTOs.DiscountDTO;
using DTOs.StadiumDTO;
using DTOs.UserDTO;
using StadiumManagerUI.Helpers;
using System;


namespace AdminUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IStadiumService _stadiumService;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public DiscountController(
            IDiscountService discountService,
            IStadiumService stadiumService,
            IUserService userService,
            ITokenService tokenService)
        {
            _discountService = discountService;
            _stadiumService = stadiumService;
            _userService = userService;
            _tokenService = tokenService;
        }

        public IActionResult DiscountList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDiscountPageData(int page = 1, int pageSize = 5, string? searchByCode = null, int? stadiumId = null, bool? isActive = null)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Phiên đăng nhập hết hạn." });
            }

            // Lấy tất cả discount (không lọc theo user)
            // Giả sử service có phương thức GetAllDiscountsAsync hỗ trợ OData
            var discountsResponse = await _discountService.GetDiscountsByUserAsync(
                accessToken,
                null,
                page,
                pageSize,
                searchByCode,
                stadiumId,
                isActive
            );

            var discounts = discountsResponse?.Value ?? new List<ReadDiscountDTO>();
            var totalCount = discountsResponse?.Count ?? 0;

            // Thu thập TargetUserIds và Creator Ids để lấy thông tin
            var userIdsToFetch = discounts
                .Where(d => !string.IsNullOrEmpty(d.TargetUserId) && int.TryParse(d.TargetUserId, out _))
                .Select(d => int.Parse(d.TargetUserId!))
                .ToList();

            userIdsToFetch.AddRange(discounts
            .Where(d => d.UserId.HasValue)
            .Select(d => d.UserId.Value));


            userIdsToFetch = userIdsToFetch.Distinct().ToList();

            var users = new List<PublicUserProfileDTO>();
            if (userIdsToFetch.Any())
            {
                users = await _userService.GetUsersByIdsAsync(userIdsToFetch, accessToken);
            }

            // Lấy tất cả sân vận động để lọc
            var stadiumsJson  = await _stadiumService.SearchStadiumAsync(""); ; // Lấy tất cả
            var stadiums = new List<ReadStadiumDTO>();
            if (!string.IsNullOrEmpty(stadiumsJson))
            {
                try
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    options.Converters.Add(new Iso8601TimeSpanConverter());
                    using (JsonDocument doc = JsonDocument.Parse(stadiumsJson))
                    {
                        if (doc.RootElement.TryGetProperty("value", out JsonElement valueElement))
                        {
                            stadiums = JsonSerializer.Deserialize<List<ReadStadiumDTO>>(valueElement.GetRawText(), options) ?? new List<ReadStadiumDTO>();
                        }
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"JSON Error parsing stadiums: {ex.Message}");
                }
            }

            // Trả về dữ liệu cho view
            return Json(new { discounts, stadiums, users, count = totalCount });
        }
    }
}