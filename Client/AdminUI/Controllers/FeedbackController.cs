using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        private string? GetAccessToken()
        {
            return Request.Cookies["AccessToken"];
        }

        private string? GetRefreshToken()
        {
            return Request.Cookies["RefreshToken"];
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
                    // Không có token → trả 401 để client biết cần login/refresh
                    return Unauthorized(new { message = "Access token missing" });
                }

                // Truyền accessToken xuống service để service có thể set Authorization header
                var (data, totalCount) = await _feedbackService.GetAllWithOdataAsync(accessToken, skip, top, filter, orderBy);

                return Json(new
                {
                    Data = data,
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


        public IActionResult Feedback()
        {
            return View();
        }
    }

}