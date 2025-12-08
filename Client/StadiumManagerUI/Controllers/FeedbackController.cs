using DTOs.NotificationDTO;
using FeedbackAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Text.Json;

namespace StadiumManagerUI.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IUserService _userService;
        private readonly INotificationService _notificationService;

        public FeedbackController(
            IFeedbackService feedbackService,
            IUserService userService,
            INotificationService notificationService
        )
        {
            _feedbackService = feedbackService;
            _userService = userService;
            _notificationService = notificationService;
        }

        private string? GetAccessToken()
        {
            return Request.Cookies["AccessToken"];
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOdata(
            int skip = 0,
            int top = 10,
            string? filter = null,
            string? orderBy = "createdAt desc")
        {
            try
            {
                var accessToken = GetAccessToken();

                if (string.IsNullOrEmpty(accessToken))
                {
                    return Unauthorized(new { message = "Access token missing" });
                }

                // Lấy feedbacks và tổng số lượng
                var (data, totalCount) = await _feedbackService.GetAllWithOdataAsync(accessToken, skip, top, filter, orderBy);

                var feedbackList = new List<object>();
                const string Profile = "https://localhost:7295";

                if (data != null && data.Any())
                {
                    var userIds = data.Select(fb => fb.UserId).Distinct().ToList();
                    var userDict = new Dictionary<int, object>();

                    foreach (var userId in userIds)
                    {
                        try
                        {
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
                            }
                            else
                            {
                                userDict[userId] = new
                                {
                                    FullName = "Anonymous",
                                    AvatarUrl = $"{Profile}/avatars/default-avatar.png"
                                };
                            }
                        }
                        catch
                        {
                            userDict[userId] = new
                            {
                                FullName = "Anonymous",
                                AvatarUrl = $"{Profile}/avatars/default-avatar.png"
                            };
                        }
                    }

                    foreach (var fb in data)
                    {
                        var userInfo = userDict.GetValueOrDefault(fb.UserId);

                        var feedbackItem = new
                        {
                            id = fb.Id,
                            rating = fb.Rating,
                            comment = fb.Comment,
                            stadiumId = fb.StadiumId,
                            userId = fb.UserId,
                            imagePath = fb.ImagePath,
                            createdAt = fb.CreatedAt,
                            userName = ((dynamic)userInfo).FullName,
                            userAvatar = ((dynamic)userInfo).AvatarUrl
                        };

                        feedbackList.Add(feedbackItem);
                    }
                }

                return Json(new
                {
                    Data = feedbackList,
                    TotalCount = totalCount,
                    Skip = skip,
                    Top = top,
                    OrderBy = orderBy,
                    Filter = filter
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Client.FeedbackController] Exception: {ex.Message}");
                return Json(new { Data = Array.Empty<object>(), TotalCount = 0 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var accessToken = GetAccessToken();

                if (string.IsNullOrEmpty(accessToken))
                {
                    return Unauthorized(new { message = "Access token missing" });
                }

                // Lấy feedback để lấy UserId
                var feedback = await _feedbackService.GetByIdAsync(accessToken, id);
                if (feedback == null)
                    return Json(new { success = false, message = "Feedback không tồn tại" });

                var result = await _feedbackService.DeleteAsync(accessToken, id);

                // Gửi thông báo chỉ cho user bị xóa feedback
                await SendNotificationForFeedback(feedback);

                if (result)
                {
                    return Json(new { success = true, message = "Xóa feedback thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Không thể xóa feedback" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FeedbackController] Delete exception: {ex.Message}");
                return Json(new { success = false, message = "Có lỗi xảy ra khi xóa feedback" });
            }
        }

        /// <summary>
        /// Gửi thông báo chỉ cho user sở hữu feedback vừa bị xóa.
        /// </summary>
        private async Task SendNotificationForFeedback(FeedbackResponse feedback)
        {
            if (feedback != null && feedback.UserId > 0)
            {
                var notification = new CreateNotificationDto
                {
                    UserId = feedback.UserId,
                    Type = "Feedback.Deleted",
                    Title = "Feedback bị xóa",
                    Message = "Feedback của bạn đã bị xóa do vi phạm tiêu chuẩn cộng đồng.",
                    Parameters = JsonSerializer.Serialize(new { feedbackId = feedback.Id, stadiumId = feedback.StadiumId })
                };

                try
                {
                    await _notificationService.SendNotificationToUserAsync(notification);
                    Console.WriteLine($"[FeedbackController] Đã gửi notification cho UserId = {feedback.UserId}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[FeedbackController] Lỗi gửi notification cho user: {ex.Message}");
                }
            }
        }

        [HttpGet]
        public IActionResult ByStadium(int stadiumId)
        {
            ViewData["stadiumId"] = stadiumId;
            return View("FeedbackByStadium");
        }

        private bool IsValidFeedback(FeedbackResponse feedback)
        {
            if (feedback == null) return false;
            if (string.IsNullOrWhiteSpace(feedback.Comment)) return false;
            return true;
        }

        [HttpGet]
        public async Task<IActionResult> GetSummary(int stadiumId)
        {
            var feedbacks = await _feedbackService.GetByStadiumIdAsync(stadiumId);
            var count = feedbacks.Count();
            var avg = count > 0 ? feedbacks.Average(f => f.Rating) : 0;
            return Json(new { count, avgRating = avg });
        }

        public IActionResult Feedback()
        {
            return View();
        }
    }
}