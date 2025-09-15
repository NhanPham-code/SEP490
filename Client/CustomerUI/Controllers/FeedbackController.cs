using FeedbackAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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
        public async Task<IActionResult> Create([FromForm] int stadiumId, [FromForm] int rating, [FromForm] string? comment, [FromForm] IFormFile? image)
        {
            try
            {
                // Add debug logging
                Console.WriteLine($"[Feedback] Received request - StadiumId: {stadiumId}, Rating: {rating}, Comment: {comment}");

                var accessToken = GetAccessToken();
                if (string.IsNullOrEmpty(accessToken))
                {
                    Console.WriteLine("[Feedback] No access token found");
                    return Unauthorized(new { message = "Bạn chưa đăng nhập hoặc phiên đã hết hạn." });
                }

                var userProfile = await _userService.GetMyProfileAsync(accessToken);
                if (userProfile == null)
                {
                    Console.WriteLine("[Feedback] Could not get user profile");
                    return Unauthorized(new { message = "Không thể lấy thông tin người dùng." });
                }

                Console.WriteLine($"[Feedback] User profile retrieved - UserId: {userProfile.UserId}");

                // ✅ Validate input parameters first
                if (stadiumId <= 0)
                {
                    Console.WriteLine($"[Feedback] Invalid stadiumId: {stadiumId}");
                    return BadRequest(new { message = "Stadium ID không hợp lệ." });
                }

                if (rating < 1 || rating > 5)
                {
                    Console.WriteLine($"[Feedback] Invalid rating: {rating}");
                    return BadRequest(new { message = "Đánh giá phải từ 1 đến 5 sao." });
                }

                if (!string.IsNullOrEmpty(comment) && comment.Length > 1000)
                {
                    Console.WriteLine($"[Feedback] Comment too long: {comment.Length} characters");
                    return BadRequest(new { message = "Bình luận không được vượt quá 1000 ký tự." });
                }

                // ✅ Check if user already gave feedback for this stadium
                var stadiumFeedbacks = await _feedbackService.GetByStadiumIdAsync(stadiumId);
                var existingFeedback = stadiumFeedbacks?.FirstOrDefault(f => f.UserId == userProfile.UserId);

                if (existingFeedback != null)
                {
                    Console.WriteLine($"[Feedback] User {userProfile.UserId} already has feedback for stadium {stadiumId}");
                    return BadRequest(new { message = "Bạn đã gửi feedback cho sân này. Vui lòng chỉnh sửa thay vì gửi mới." });
                }

                // ✅ Validate image file if provided
                if (image != null)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        Console.WriteLine($"[Feedback] Invalid file extension: {fileExtension}");
                        return BadRequest(new { message = "Chỉ cho phép upload ảnh định dạng JPG, JPEG, PNG, GIF." });
                    }

                    if (image.Length > 5 * 1024 * 1024) // 5MB
                    {
                        Console.WriteLine($"[Feedback] File too large: {image.Length} bytes");
                        return BadRequest(new { message = "Kích thước ảnh không được vượt quá 5MB." });
                    }
                }

                // ✅ Create feedback DTO
                var feedbackDto = new CreateFeedback
                {
                    UserId = userProfile.UserId,
                    StadiumId = stadiumId,
                    Rating = rating,
                    Comment = comment,
                    Image = image
                };

                Console.WriteLine($"[Feedback] Creating feedback DTO - UserId: {feedbackDto.UserId}, StadiumId: {feedbackDto.StadiumId}, Rating: {feedbackDto.Rating}");

                var createdFeedback = await _feedbackService.CreateAsync(feedbackDto, accessToken);

                if (createdFeedback == null)
                {
                    Console.WriteLine("[Feedback] CreateAsync returned null");
                    return StatusCode(500, new { message = "Không thể tạo phản hồi." });
                }

                Console.WriteLine("[Feedback] Feedback created successfully");
                return Ok(new { success = true, message = "Gửi phản hồi thành công!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Feedback] Exception occurred: {ex.Message}");
                Console.WriteLine($"[Feedback] Stack trace: {ex.StackTrace}");
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
                ViewBag.CurrentImagePath = feedback.ImagePath; // ✅ Truyền đường dẫn ảnh hiện tại
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
        public async Task<IActionResult> Edit(int id, [FromForm] int rating, [FromForm] string? comment, [FromForm] IFormFile? image)
        {
            try
            {
                var accessToken = GetAccessToken();
                if (string.IsNullOrEmpty(accessToken))
                    return Unauthorized(new { success = false, message = "Bạn chưa đăng nhập hoặc phiên đã hết hạn." });

                var feedback = await _feedbackService.GetByIdAsync(accessToken, id);
                var userProfile = await _userService.GetMyProfileAsync(accessToken);

                if (feedback == null || userProfile == null || feedback.UserId != userProfile.UserId)
                    return Unauthorized(new { success = false, message = "Bạn không có quyền chỉnh sửa feedback này." });

                // ✅ Validate dữ liệu
                if (rating < 1 || rating > 5)
                    return BadRequest(new { success = false, message = "Đánh giá phải từ 1 đến 5 sao." });

                if (!string.IsNullOrEmpty(comment) && comment.Length > 1000)
                    return BadRequest(new { success = false, message = "Bình luận không được vượt quá 1000 ký tự." });

                // ✅ Validate file ảnh nếu có
                if (image != null)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();

                    if (!allowedExtensions.Contains(fileExtension))
                        return BadRequest(new { success = false, message = "Chỉ cho phép upload ảnh định dạng JPG, JPEG, PNG, GIF." });

                    if (image.Length > 5 * 1024 * 1024) // 5MB
                        return BadRequest(new { success = false, message = "Kích thước ảnh không được vượt quá 5MB." });
                }

                // ✅ Tạo DTO với ảnh
                var updateDto = new UpdateFeedback
                {
                    Rating = rating,
                    Comment = comment,
                    Image = image // ✅ Bổ sung field ảnh
                };

                // ✅ Luôn update (không bao giờ create mới)
                var isUpdated = await _feedbackService.UpdateAsync(accessToken, id, updateDto);

                if (!isUpdated)
                    return StatusCode(500, new { success = false, message = "Không thể cập nhật phản hồi. Vui lòng thử lại." });

                return Json(new { success = true, message = "Cập nhật phản hồi thành công!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Feedback Edit] Lỗi khi update feedback: " + ex.Message);
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
        public async Task<IActionResult> GetFeedbacksByStadiumDirect(int stadiumId, int page = 1, int pageSize = 5)
        {
            try
            {
                var stadiumFeedbacks = await _feedbackService.GetByStadiumIdAsync(stadiumId);
                var feedbackList = new List<object>();
                const string BASE_URL= "https://localhost:7221"; // Sửa lại base URL nếu khác
                const string Profile = "https://localhost:7295";
                if (stadiumFeedbacks != null && stadiumFeedbacks.Any())
                {
                    // Lấy userId dạng int, không chuyển sang string
                    var userIds = stadiumFeedbacks.Select(f => f.UserId).Distinct().ToList();
                    var userDict = new Dictionary<int, object>();

                    Console.WriteLine($"[GetFeedbacksByStadiumDirect] Processing {userIds.Count} unique users");

                    foreach (var userId in userIds)
                    {
                        try
                        {
                            Console.WriteLine($"[GetFeedbacksByStadiumDirect] Getting user info for userId: {userId}");

                            // Sử dụng int, không phải string
                            var userInfo = await _userService.GetOtherUserByIdAsync(userId);

                            if (userInfo != null)
                            {
                                var avatarFullUrl = !string.IsNullOrEmpty(userInfo.AvatarUrl)
                                    ? $"{Profile}{userInfo.AvatarUrl}"
                                    : $"{Profile}/avatars/default-avatar.png";

                                userDict[userId] = new
                                {
                                    FullName = userInfo.FullName ?? "Anonymous",
                                    AvatarUrl = avatarFullUrl
                                };

                                Console.WriteLine($"[GetFeedbacksByStadiumDirect] User {userId}: Name={userInfo.FullName}, Avatar={avatarFullUrl}");
                            }
                            else
                            {
                                Console.WriteLine($"[GetFeedbacksByStadiumDirect] User {userId}: NULL response from API");
                                userDict[userId] = new
                                {
                                    FullName = "Anonymous",
                                    AvatarUrl = $"{Profile}/avatars/default-avatar.png"
                                };
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[GetFeedbacksByStadiumDirect] Error getting user {userId}: {ex.Message}");
                            userDict[userId] = new
                            {
                                FullName = "Anonymous",
                                AvatarUrl = $"{Profile}/avatars/default-avatar.png"
                            };
                        }
                    }

                    var allFeedbacks = new List<object>();
                    foreach (var fb in stadiumFeedbacks.OrderByDescending(f => f.CreatedAt))
                    {
                        // Lấy theo int userId
                        var userInfo = userDict.GetValueOrDefault(fb.UserId);

                        string imageFullUrl = null;
                        if (!string.IsNullOrEmpty(fb.ImagePath))
                        {
                            imageFullUrl = $"{BASE_URL}{fb.ImagePath}";
                        }

                        var feedbackItem = new
                        {
                            id = fb.Id,
                            rating = fb.Rating,
                            comment = fb.Comment,
                            stadiumId = fb.StadiumId,
                            userId = fb.UserId,
                            imagePath = imageFullUrl,
                            createdAt = fb.CreatedAt,
                            userName = ((dynamic)userInfo).FullName,
                            userAvatar = ((dynamic)userInfo).AvatarUrl
                        };

                        Console.WriteLine($"[GetFeedbacksByStadiumDirect] Feedback {fb.Id}: User={feedbackItem.userName}, Image={imageFullUrl}");

                        allFeedbacks.Add(feedbackItem);
                    }

                    // Phân trang
                    var totalCount = allFeedbacks.Count;
                    var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
                    var skip = (page - 1) * pageSize;

                    feedbackList = allFeedbacks.Skip(skip).Take(pageSize).ToList();

                    Console.WriteLine($"[GetFeedbacksByStadiumDirect] Page {page}/{totalPages}, Returning {feedbackList.Count}/{totalCount} feedbacks");

                    return Json(new
                    {
                        success = true,
                        data = feedbackList,
                        pagination = new
                        {
                            currentPage = page,
                            pageSize = pageSize,
                            totalCount = totalCount,
                            totalPages = totalPages,
                            hasNextPage = page < totalPages,
                            hasPreviousPage = page > 1
                        }
                    });
                }

                Console.WriteLine($"[GetFeedbacksByStadiumDirect] No feedbacks found");

                return Json(new
                {
                    success = true,
                    data = new List<object>(),
                    pagination = new
                    {
                        currentPage = 1,
                        pageSize = pageSize,
                        totalCount = 0,
                        totalPages = 0,
                        hasNextPage = false,
                        hasPreviousPage = false
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetFeedbacksByStadiumDirect] Exception: {ex.Message}");
                Console.WriteLine($"[GetFeedbacksByStadiumDirect] Stack trace: {ex.StackTrace}");
                return Json(new { success = false, message = ex.Message, data = new List<object>() });
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

                if (myFeedback != null)
                {
                    // ✅ Xử lý imagePath - chỉ tạo full URL nếu có imagePath
                    string imageFullUrl = null;
                    if (!string.IsNullOrEmpty(myFeedback.ImagePath))
                    {
                        imageFullUrl = $"https://localhost:7221{myFeedback.ImagePath}";
                    }

                    Console.WriteLine($"[GetMyFeedbackForStadium] Found feedback {myFeedback.Id} with image: {imageFullUrl}");

                    return Json(new
                    {
                        success = true,
                        data = new
                        {
                            id = myFeedback.Id,
                            rating = myFeedback.Rating,
                            comment = myFeedback.Comment,
                            imagePath = imageFullUrl, // ✅ Full URL hoặc null
                            createdAt = myFeedback.CreatedAt,
                            stadiumId = myFeedback.StadiumId,
                            userId = myFeedback.UserId
                        }
                    });
                }

                return Json(new { success = false, message = "Bạn chưa có feedback cho sân này." });
            }
            catch (Exception ex)
            {
                Console.WriteLine("[GetMyFeedbackForStadium] Lỗi: " + ex.Message);
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditFeedback([FromForm] int feedbackId, [FromForm] int rating, [FromForm] string? comment, [FromForm] IFormFile? image)
        {
            try
            {
                Console.WriteLine($"[EditFeedback] START - FeedbackId: {feedbackId}, Rating: {rating}");
                Console.WriteLine($"[EditFeedback] Comment: '{comment}'");
                Console.WriteLine($"[EditFeedback] Image: {(image != null ? $"{image.FileName} ({image.Length} bytes)" : "null")}");

                var accessToken = GetAccessToken();
                if (string.IsNullOrEmpty(accessToken))
                {
                    Console.WriteLine("[EditFeedback] No access token");
                    return Json(new { success = false, message = "Bạn chưa đăng nhập hoặc phiên đã hết hạn." });
                }

                var feedback = await _feedbackService.GetByIdAsync(accessToken, feedbackId);
                var userProfile = await _userService.GetMyProfileAsync(accessToken);

                Console.WriteLine($"[EditFeedback] Feedback found: {feedback != null}");
                Console.WriteLine($"[EditFeedback] User profile: {userProfile != null}");

                if (feedback == null)
                {
                    Console.WriteLine("[EditFeedback] Feedback not found");
                    return Json(new { success = false, message = "Không tìm thấy feedback." });
                }

                if (userProfile == null)
                {
                    Console.WriteLine("[EditFeedback] User profile not found");
                    return Json(new { success = false, message = "Không thể lấy thông tin người dùng." });
                }

                if (feedback.UserId != userProfile.UserId)
                {
                    Console.WriteLine($"[EditFeedback] Permission denied - Feedback UserId: {feedback.UserId}, Current UserId: {userProfile.UserId}");
                    return Json(new { success = false, message = "Bạn không có quyền chỉnh sửa feedback này." });
                }

                // Validate
                if (rating < 1 || rating > 5)
                {
                    Console.WriteLine($"[EditFeedback] Invalid rating: {rating}");
                    return Json(new { success = false, message = "Đánh giá phải từ 1 đến 5 sao." });
                }

                if (!string.IsNullOrEmpty(comment) && comment.Length > 500)
                {
                    Console.WriteLine($"[EditFeedback] Comment too long: {comment.Length}");
                    return Json(new { success = false, message = "Bình luận không được vượt quá 500 ký tự." });
                }

                // Validate image
                if (image != null)
                {
                    Console.WriteLine($"[EditFeedback] Validating image: {image.FileName}");
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                    var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        Console.WriteLine($"[EditFeedback] Invalid file extension: {fileExtension}");
                        return Json(new { success = false, message = "Chỉ cho phép upload ảnh định dạng JPG, JPEG, PNG, GIF." });
                    }

                    if (image.Length > 5 * 1024 * 1024)
                    {
                        Console.WriteLine($"[EditFeedback] File too large: {image.Length}");
                        return Json(new { success = false, message = "Kích thước ảnh không được vượt quá 5MB." });
                    }
                }

                var updateDto = new UpdateFeedback
                {
                    Rating = rating,
                    Comment = comment,
                    Image = image
                };

                Console.WriteLine($"[EditFeedback] Calling UpdateAsync with DTO - Rating: {updateDto.Rating}");

                var isUpdated = await _feedbackService.UpdateAsync(accessToken, feedbackId, updateDto);

                Console.WriteLine($"[EditFeedback] UpdateAsync result: {isUpdated}");

                if (!isUpdated)
                {
                    Console.WriteLine("[EditFeedback] Update failed");
                    return Json(new { success = false, message = "Không thể cập nhật phản hồi. Vui lòng thử lại." });
                }

                // Get updated feedback
                var updatedFeedback = await _feedbackService.GetByIdAsync(accessToken, feedbackId);

                Console.WriteLine($"[EditFeedback] SUCCESS - Updated feedback retrieved");

                return Json(new
                {
                    success = true,
                    message = "Cập nhật phản hồi thành công!",
                    data = new
                    {
                        id = updatedFeedback.Id,
                        rating = updatedFeedback.Rating,
                        comment = updatedFeedback.Comment,
                        imagePath = updatedFeedback.ImagePath,
                        createdAt = updatedFeedback.CreatedAt,
                        userName = userProfile.FullName ?? "Anonymous"
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[EditFeedback] EXCEPTION: {ex.Message}");
                Console.WriteLine($"[EditFeedback] Stack trace: {ex.StackTrace}");
                return Json(new { success = false, message = $"Có lỗi xảy ra: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFeedback(int feedbackId)
        {
            try
            {
                var accessToken = GetAccessToken();
                if (string.IsNullOrEmpty(accessToken))
                    return Json(new { success = false, message = "Bạn chưa đăng nhập hoặc phiên đã hết hạn." });

                var feedback = await _feedbackService.GetByIdAsync(accessToken, feedbackId);
                var userProfile = await _userService.GetMyProfileAsync(accessToken);

                if (feedback == null || userProfile == null || feedback.UserId != userProfile.UserId)
                    return Json(new { success = false, message = "Bạn không có quyền xóa feedback này." });

                var isDeleted = await _feedbackService.DeleteAsync(accessToken, feedbackId);

                if (!isDeleted)
                    return Json(new { success = false, message = "Không thể xóa phản hồi. Vui lòng thử lại." });

                return Json(new { success = true, message = "Xóa phản hồi thành công!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine("[DeleteFeedback] Lỗi: " + ex.Message);
                return Json(new { success = false, message = $"Có lỗi xảy ra: {ex.Message}" });
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

                var otherUser = await _userService.GetOtherUserByIdAsync(userId);
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