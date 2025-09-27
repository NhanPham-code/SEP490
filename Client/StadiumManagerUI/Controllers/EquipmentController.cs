using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using DTOs.StadiumEquipmentDTO;
using DTOs.StadiumDTO;
using StadiumManagerUI.Helpers;

namespace StadiumManagerUI.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IStadiumEquipmentService _stadiumEquipmentService;
        private readonly IStadiumService _stadiumService;
        private readonly ITokenService _tokenService;

        public EquipmentController(
            IStadiumEquipmentService stadiumEquipmentService,
            IStadiumService stadiumService,
            ITokenService tokenService)
        {
            _stadiumEquipmentService = stadiumEquipmentService;
            _stadiumService = stadiumService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStadiumEquipmentPageData(int page = 1, int pageSize = 5, string? searchByName = null, int? stadiumId = null, string? status = null)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { message = "Phiên đăng nhập hết hạn." });
            }

            var userId = HttpContext.Session.GetInt32("UserId");

            // Lấy stadiumId từ session nếu không được truyền
            if (stadiumId == null)
            {
                var sessionStadiumId = HttpContext.Session.GetInt32("currentStadiumId");
                if (sessionStadiumId.HasValue)
                {
                    stadiumId = sessionStadiumId.Value;
                }
            }

            if (stadiumId == null)
            {
                return BadRequest(new { message = "Không tìm thấy thông tin sân." });
            }

            try
            {
                // Lấy danh sách stadium equipment với phân trang
                var equipmentResponseTask = _stadiumEquipmentService.GetByStadiumIdPagedAsync(stadiumId.Value, page, pageSize);

                // Lấy danh sách stadium của user để hiển thị dropdown
                string filter = $"&$filter=CreatedBy eq {userId}";
                var stadiumsJsonTask = _stadiumService.SearchStadiumAsync(filter);

                await Task.WhenAll(equipmentResponseTask, stadiumsJsonTask);

                // Xử lý equipment
                var equipmentResponse = equipmentResponseTask.Result;
                var equipments = equipmentResponse.data;
                var totalCount = equipmentResponse.totalCount;

                // Áp dụng search filter nếu có
                if (!string.IsNullOrEmpty(searchByName))
                {
                    equipments = equipments.Where(e => e.Name.Contains(searchByName, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    equipments = equipments.Where(e => e.Status == status);
                }

                // Xử lý stadium
                var stadiumsJson = stadiumsJsonTask.Result;
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
                        Debug.WriteLine($"JSON Error parsing stadiums: {ex.Message}");
                    }
                }

                return Json(new { equipments, stadiums, count = totalCount, currentStadiumId = stadiumId });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetStadiumEquipmentPageData: {ex.Message}");
                return StatusCode(500, new { message = "Lỗi server khi tải dữ liệu thiết bị." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment([FromForm] CreateStadiumEquipment dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { success = false, message = "Phiên đăng nhập hết hạn." });
            }

            if (dto == null)
            {
                return BadRequest(new { success = false, message = "Dữ liệu thiết bị không hợp lệ." });
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest(new { success = false, message = "Tên thiết bị là bắt buộc." });
            }

            if (dto.QuantityTotal <= 0)
            {
                return BadRequest(new { success = false, message = "Tổng số lượng phải lớn hơn 0." });
            }

            if (dto.QuantityAvailable < 0)
            {
                return BadRequest(new { success = false, message = "Số lượng có sẵn không được âm." });
            }

            if (dto.QuantityAvailable > dto.QuantityTotal)
            {
                return BadRequest(new { success = false, message = "Số lượng có sẵn không thể lớn hơn tổng số lượng." });
            }

            if (dto.StadiumId <= 0)
            {
                return BadRequest(new { success = false, message = "Thông tin sân không hợp lệ." });
            }

            try
            {
                var createdEquipment = await _stadiumEquipmentService.CreateAsync(dto, accessToken);

                if (createdEquipment == null)
                {
                    return StatusCode(500, new { success = false, message = "Tạo thiết bị thất bại." });
                }

                return Json(new { success = true, data = createdEquipment, message = "Tạo thiết bị thành công." });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error creating equipment: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Lỗi server khi tạo thiết bị." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEquipmentById(int id)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { success = false, message = "Phiên đăng nhập hết hạn." });
            }

            if (id <= 0)
            {
                return BadRequest(new { success = false, message = "ID thiết bị không hợp lệ." });
            }

            try
            {
                var equipment = await _stadiumEquipmentService.GetByIdAsync(accessToken, id);

                if (equipment == null)
                {
                    return NotFound(new { success = false, message = "Không tìm thấy thiết bị." });
                }

                return Json(new { success = true, data = equipment });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting equipment by id: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Lỗi server khi tải thông tin thiết bị." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEquipment(int id, [FromForm] UpdateStadiumEquipment dto)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { success = false, message = "Phiên đăng nhập hết hạn." });
            }

            if (dto == null || id <= 0)
            {
                return BadRequest(new { success = false, message = "Dữ liệu không hợp lệ." });
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                return BadRequest(new { success = false, message = "Tên thiết bị là bắt buộc." });
            }

            if (dto.QuantityTotal <= 0)
            {
                return BadRequest(new { success = false, message = "Tổng số lượng phải lớn hơn 0." });
            }

            if (dto.QuantityAvailable < 0)
            {
                return BadRequest(new { success = false, message = "Số lượng có sẵn không được âm." });
            }

            if (dto.QuantityAvailable > dto.QuantityTotal)
            {
                return BadRequest(new { success = false, message = "Số lượng có sẵn không thể lớn hơn tổng số lượng." });
            }

            try
            {
                bool success = await _stadiumEquipmentService.UpdateAsync(accessToken, id, dto);

                if (!success)
                {
                    return StatusCode(500, new { success = false, message = "Cập nhật thiết bị thất bại." });
                }

                var updatedEquipment = await _stadiumEquipmentService.GetByIdAsync(accessToken, id);
                return Json(new { success = true, data = updatedEquipment, message = "Cập nhật thiết bị thành công." });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating equipment: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Lỗi server khi cập nhật thiết bị." });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            var accessToken = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized(new { success = false, message = "Phiên đăng nhập hết hạn." });
            }

            if (id <= 0)
            {
                return BadRequest(new { success = false, message = "ID thiết bị không hợp lệ." });
            }

            try
            {
                bool success = await _stadiumEquipmentService.DeleteAsync(accessToken, id);

                if (!success)
                {
                    return StatusCode(500, new { success = false, message = "Xóa thiết bị thất bại." });
                }

                return Json(new { success = true, message = "Xóa thiết bị thành công." });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deleting equipment: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Lỗi server khi xóa thiết bị." });
            }
        }

        [HttpPost]
        public IActionResult SetCurrentStadiumId(int stadiumId)
        {
            try
            {
                if (stadiumId <= 0)
                {
                    return BadRequest(new { success = false, message = "Stadium ID không hợp lệ." });
                }

                HttpContext.Session.SetInt32("currentStadiumId", stadiumId);
                return Json(new { success = true, message = "Đã lưu thông tin sân vào session." });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error setting stadium ID: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Lỗi khi lưu thông tin sân." });
            }
        }

        [HttpGet]
        public IActionResult GetCurrentStadiumId()
        {
            try
            {
                var stadiumId = HttpContext.Session.GetInt32("currentStadiumId");
                return Json(new { success = true, stadiumId });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting stadium ID: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Lỗi khi lấy thông tin sân." });
            }
        }
    }
}