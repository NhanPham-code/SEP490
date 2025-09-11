using FeedbackAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerUI.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
         private static readonly string BASE_URL = "https://localhost:7136"; // URL của Gateway của bạn
        public FeedbackController(IFeedbackService feedbackService, ITokenService tokenService, IUserService userService)
        {
            _feedbackService = feedbackService;
            _tokenService = tokenService;
            _userService = userService;
        }

        private string? GetAccessToken()
        {
            return Request.Cookies["AccessToken"];
        }

        private string? GetRefreshToken()
        {
            return Request.Cookies["RefreshToken"];
        }

        // GET: Feedback
        public async Task<IActionResult> Index()
        {
            try
            {
                var accessToken = GetAccessToken();
                if (string.IsNullOrEmpty(accessToken))
                {
                    // For public viewing, you might want to allow viewing without token
                    // or redirect to login - adjust based on your requirements
                    TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                    return RedirectToAction("Login", "Common");
                }

                var feedbacks = await _feedbackService.GetAllAsync(accessToken);
                return View(feedbacks);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Feedback] Lỗi khi lấy danh sách feedback: " + ex.Message);
                TempData["ErrorMessage"] = "Lỗi khi lấy danh sách phản hồi.";
                return View(new List<FeedbackResponse>());
            }
        }

        // GET: Feedback/Create
        public IActionResult Create(string stadiumId)
        {
            var accessToken = GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                return RedirectToAction("Login", "Common");
            }

            if (string.IsNullOrEmpty(stadiumId))
            {
                TempData["ErrorMessage"] = "Stadium ID không hợp lệ.";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.StadiumId = stadiumId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int stadiumId, int rating, string? comment)
        {
            try
            {
                var accessToken = GetAccessToken();
                if (string.IsNullOrEmpty(accessToken))
                    return Unauthorized(new { message = "Bạn chưa đăng nhập hoặc phiên đã hết hạn." });

                var userProfile = await _userService.GetMyProfileAsync(accessToken);
                if (userProfile == null)
                    return Unauthorized(new { message = "Không thể lấy thông tin người dùng." });

                // ✅ Check nếu user đã feedback sân này chưa
                var stadiumFeedbacks = await _feedbackService.GetByStadiumIdAsync(stadiumId);
                var existingFeedback = stadiumFeedbacks?.FirstOrDefault(f => f.UserId == userProfile.UserId);

                if (existingFeedback != null)
                {
                    return BadRequest(new { message = "Bạn đã gửi feedback cho sân này. Vui lòng chỉnh sửa thay vì gửi mới." });
                }

                var feedbackDto = new CreateFeedback
                {
                    UserId = userProfile.UserId,
                    StadiumId = stadiumId,
                    Rating = rating,
                    Comment = comment
                };

                if (!ModelState.IsValid)
                    return BadRequest(new { message = "Thông tin phản hồi không hợp lệ." });

                var createdFeedback = await _feedbackService.CreateAsync(feedbackDto, accessToken);

                if (createdFeedback == null)
                    return StatusCode(500, new { message = "Không thể tạo phản hồi." });

                return Ok(new { success = true, message = "Gửi phản hồi thành công!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Feedback] Lỗi khi tạo feedback: " + ex.Message);
                return StatusCode(500, new { message = "Có lỗi xảy ra khi tạo feedback." });
            }
        }




        // GET: Feedback/MyFeedbacks
        public async Task<IActionResult> MyFeedbacks()
        {
            var accessToken = GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                return RedirectToAction("Login", "Common");
            }

            try
            {
                // Lấy thông tin user để có UserId
                var userProfile = await _userService.GetMyProfileAsync(accessToken);
                if (userProfile == null)
                {
                    TempData["ErrorMessage"] = "Không thể lấy thông tin người dùng.";
                    return RedirectToAction("Login", "Common");
                }

                // Lấy tất cả feedback và filter theo UserId
                var allFeedbacks = await _feedbackService.GetAllAsync(accessToken);
                var userFeedbacks = allFeedbacks.Where(f => f.UserId == userProfile.UserId).ToList();

                Console.WriteLine($"[MyFeedbacks] Đã lấy được {userFeedbacks.Count} feedback(s) của user {userProfile.UserId}:");
                foreach (var f in userFeedbacks)
                {
                    Console.WriteLine($" - Feedback Id: {f.Id}, Rating: {f.Rating}, Stadium: {f.StadiumId}");
                }

                return View(userFeedbacks);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[MyFeedbacks] Lỗi khi lấy feedback của user: " + ex.Message);
                TempData["ErrorMessage"] = "Lỗi khi lấy danh sách phản hồi của bạn.";
                return View(new List<FeedbackResponse>());
            }
        }

        // GET: Feedback/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var accessToken = GetAccessToken();
                if (string.IsNullOrEmpty(accessToken))
                {
                    TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                    return RedirectToAction("Login", "Common");
                }

                var feedback = await _feedbackService.GetByIdAsync(accessToken, id);
                if (feedback == null)
                {
                    TempData["ErrorMessage"] = "Không tìm thấy phản hồi.";
                    return RedirectToAction("Index");
                }

                return View(feedback);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Feedback Details] Lỗi khi lấy chi tiết feedback: " + ex.Message);
                TempData["ErrorMessage"] = "Lỗi khi lấy thông tin phản hồi.";
                return RedirectToAction("Index");
            }
        }

        // GET: Feedback/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var accessToken = GetAccessToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                return RedirectToAction("Login", "Common");
            }

            try
            {
                var feedback = await _feedbackService.GetByIdAsync(accessToken, id);
                if (feedback == null)
                {
                    TempData["ErrorMessage"] = "Không tìm thấy phản hồi.";
                    return RedirectToAction("MyFeedbacks");
                }

                // Kiểm tra xem feedback có thuộc về user hiện tại không
                var userProfile = await _userService.GetMyProfileAsync(accessToken);
                if (userProfile == null || feedback.UserId != userProfile.UserId)
                {
                    TempData["ErrorMessage"] = "Bạn không có quyền chỉnh sửa phản hồi này.";
                    return RedirectToAction("MyFeedbacks");
                }

                var updateDto = new UpdateFeedback
                {
                    Rating = feedback.Rating,
                    Comment = feedback.Comment
                };

                ViewBag.FeedbackId = id;
                ViewBag.StadiumId = feedback.StadiumId;
                return View(updateDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Feedback Edit] Lỗi khi lấy feedback để edit: " + ex.Message);
                TempData["ErrorMessage"] = "Lỗi khi lấy thông tin phản hồi.";
                return RedirectToAction("MyFeedbacks");
            }
        }


        // POST: Feedback/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateFeedback updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false, message = "Thông tin cập nhật không hợp lệ." });

                var accessToken = GetAccessToken();
                if (string.IsNullOrEmpty(accessToken))
                    return Unauthorized(new { success = false, message = "Bạn chưa đăng nhập hoặc phiên đã hết hạn." });

                var feedback = await _feedbackService.GetByIdAsync(accessToken, id);
                var userProfile = await _userService.GetMyProfileAsync(accessToken);

                if (feedback == null || userProfile == null || feedback.UserId != userProfile.UserId)
                    return Unauthorized(new { success = false, message = "Bạn không có quyền chỉnh sửa feedback này." });

                // ✅ Luôn update (không bao giờ create mới)
                var isUpdated = await _feedbackService.UpdateAsync(accessToken, id, updateDto);

                if (!isUpdated)
                    return StatusCode(500, new { success = false, message = "Không thể cập nhật phản hồi. Vui lòng thử lại." });

                return Json(new { success = true, message = "Cập nhật phản hồi thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Có lỗi xảy ra: {ex.Message}" });
            }
        }



        // POST: Feedback/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var accessToken = GetAccessToken();
                if (string.IsNullOrEmpty(accessToken))
                {
                    TempData["ErrorMessage"] = "Bạn chưa đăng nhập hoặc phiên đã hết hạn.";
                    return RedirectToAction("Login", "Common");
                }

                // Kiểm tra quyền sở hữu feedback
                var feedback = await _feedbackService.GetByIdAsync(accessToken, id);
                var userProfile = await _userService.GetMyProfileAsync(accessToken);

                if (feedback == null || userProfile == null || feedback.UserId != userProfile.UserId)
                {
                    TempData["ErrorMessage"] = "Bạn không có quyền xóa phản hồi này.";
                    return RedirectToAction("MyFeedbacks");
                }

                var isDeleted = await _feedbackService.DeleteAsync(accessToken, id);

                if (!isDeleted)
                {
                    TempData["ErrorMessage"] = "Không thể xóa phản hồi. Vui lòng thử lại.";
                }
                else
                {
                    TempData["SuccessMessage"] = "Xóa phản hồi thành công!";
                }

                return RedirectToAction("MyFeedbacks");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Feedback Delete] Lỗi khi xóa feedback: " + ex.Message);
                TempData["ErrorMessage"] = $"Có lỗi xảy ra: {ex.Message}";
                return RedirectToAction("MyFeedbacks");
            }
        }

        // GET: API endpoint để lấy feedbacks theo stadiumId

        [HttpGet]
        public async Task<IActionResult> GetFeedbacksByStadium(int stadiumId)
        {
            try
            {
                // Gọi trực tiếp service chuyên lấy feedback theo StadiumId
                var stadiumFeedbacks = await _feedbackService.GetByStadiumIdAsync(stadiumId);

                return Json(new
                {
                    success = true,
                    data = stadiumFeedbacks ?? new List<FeedbackResponse>(),
                    count = stadiumFeedbacks?.Count() ?? 0
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("[GetFeedbacksByStadium] Lỗi khi lấy feedback theo stadium: " + ex.Message);
                return Json(new
                {
                    success = false,
                    message = "Lỗi khi lấy danh sách phản hồi.",
                    data = new List<FeedbackResponse>()
                });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetFeedbacksByStadiumDirect(int stadiumId)
        {
            try
            {
                var stadiumFeedbacks = await _feedbackService.GetByStadiumIdAsync(stadiumId);

                var feedbackList = new List<object>();

                if (stadiumFeedbacks != null)
                {
                    foreach (var fb in stadiumFeedbacks)
                    {
                        feedbackList.Add(new
                        {
                            fb.Id,
                            fb.Rating,
                            fb.Comment,
                            fb.StadiumId,
                            fb.UserId
                        });
                    }
                }

                return Json(new
                {
                    success = true,
                    data = feedbackList,
                    count = feedbackList.Count
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetMyFeedbackForStadium(int stadiumId)
        {
            try
            {
                var accessToken = GetAccessToken();
                if (string.IsNullOrEmpty(accessToken))
                    return Json(new { success = false, message = "Bạn chưa đăng nhập." });

                var userProfile = await _userService.GetMyProfileAsync(accessToken);
                if (userProfile == null)
                    return Json(new { success = false, message = "Không thể lấy thông tin user." });

                var stadiumFeedbacks = await _feedbackService.GetByStadiumIdAsync(stadiumId);
                var myFeedback = stadiumFeedbacks?.FirstOrDefault(f => f.UserId == userProfile.UserId);

                return Json(new { success = true, data = myFeedback });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetOtherUserProfile(int userId)
        {
            try
            {
                if (userId <= 0)
                    return BadRequest(new { success = false, message = "UserId không hợp lệ." });

                var otherUser = await _userService.GetOtherUserByIdAsync(userId.ToString());
                if (otherUser == null)
                    return NotFound(new { success = false, message = "Không tìm thấy thông tin người dùng." });

                return Json(new { success = true, data = otherUser });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetOtherUserProfile] Lỗi: {ex.Message}");
                return StatusCode(500, new { success = false, message = "Có lỗi xảy ra khi lấy thông tin user." });
            }
        }



    }
}