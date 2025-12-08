using DTOs.NotificationDTO;
using DTOs.StadiumDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    public class StadiumController : Controller
    {

        private readonly IStadiumService _service;
        private readonly IStadiumImageService _imageService;
        private readonly IStadiumVideoSetvice _videoService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly INotificationService _notificationService;

        public StadiumController(IStadiumService stadiumService, IStadiumImageService stadiumImageService, IStadiumVideoSetvice stadiumVideoSetvice, ITokenService tokenService, IUserService userService, INotificationService notificationService)
        {
            _service = stadiumService;
            _imageService = stadiumImageService;
            _videoService = stadiumVideoSetvice;
            _tokenService = tokenService;
            _userService = userService;
            _notificationService = notificationService;
        }
        public IActionResult StadiumAdmin()
        {
            var token = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(token) == false)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        public async Task<IActionResult> GetAllAndSearch(string url)
        {
            var token = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(token) == false)
            {
                var stadium = await _service.SearchStadiumAsync(url+= "&$orderby=CreatedAt desc");
                return Content(stadium, "application/json");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

        public async Task<IActionResult> LockStadium(int id)
        {

            var locked = await _service.DeleteStadiumAsync(id);
            List<int> ids = new List<int>();
            ids.Add(id);
            var stadium = await _service.GetAllStadiumByListId(ids);
            // id của chủ sân
            int createdBy = stadium.Value.FirstOrDefault().CreatedBy;
            if (locked)
            {
                var islock = stadium.Value.FirstOrDefault();
                if ( islock.IsLocked == true)
                {
                    // thông báo cho chủ sân khi bị khóa sân
                    _ = await _notificationService.SendNotificationToUserAsync(new CreateNotificationDto
                    {
                        Title = "<h3 class=\"text-red\">Sân của bạn đã bị khóa</h3>",
                        Message = $"Sân '{islock.Name}' của bạn đã bị khóa do vi phạm các quy định của hệ thống. Vui lòng liên hệ với quản trị viên để biết thêm chi tiết.",
                        UserId = createdBy
                    });
                    return Json(new { success = 200, value = "Sân được khóa thành công!" });
                }
                else
                {
                    // thông báo cho chủ sân khi được mở khóa sân
                    _ = await _notificationService.SendNotificationToUserAsync(new CreateNotificationDto
                    {
                        Title = "<h3 class=\"text-green-700\">Sân của bạn đã được mở khóa</h3>",
                        Message = $"Sân '{islock.Name}' của bạn đã được mở khóa. Cảm ơn bạn đã tuân thủ các quy định của hệ thống.",
                        UserId = createdBy
                    });
                    return Json(new { success = 200, value = "Sân được mở khóa thành công!" });
                }
            }
            else
                return Json(new { success = 400, value = locked });
        }

        // chap nhan san dau
        public async Task<IActionResult> AcceptStadium(int id)
        {
            var stadium = await _service.GetStadiumByIdAsync(id);
            UpdateStadiumDTO updateStadiumDTO = new UpdateStadiumDTO
            {
                Name = stadium.Name,
                Address = stadium.Address,
                Description = stadium.Description,
                NameUnsigned = stadium.NameUnsigned,
                AddressUnsigned = stadium.AddressUnsigned,
                CreatedBy = stadium.CreatedBy,
                CloseTime = stadium.CloseTime,
                OpenTime = stadium.OpenTime,
                IsApproved = true,
                Id = stadium.Id,
                IsLocked = stadium.IsLocked,
                Latitude = stadium.Latitude,
                Longitude = stadium.Longitude
            };
            var updatedStadium = await _service.UpdateStadiumAsync(id, updateStadiumDTO);
            
            
            if (updatedStadium != null && updatedStadium.IsApproved == true)
            {

                // thông báo cho chủ sân khi được duyệt sân
                _ = await _notificationService.SendNotificationToUserAsync(new CreateNotificationDto
                {
                    Title = "<h3 class=\"text-green-700\">Sân của bạn đã được duyệt</h3>",
                    Message = $"Sân '{updatedStadium.Name}' của bạn đã được duyệt và hiển thị trên hệ thống. Cảm ơn bạn đã đăng ký sân với chúng tôi.",
                    UserId = updatedStadium.CreatedBy
                });
                return Json(new { success = 200, value = "Sân được duyệt thành công!" });

            }
            else
                return Json(new { success = 400, value = updatedStadium });
        }

        // lấy những sân vừa đăng kí hôm nay
        public async Task<IActionResult> GetNewStadiums()
        {
            var token = _tokenService.GetAccessTokenFromCookie();

            // hôm nay (UTC)
            var today = DateTime.UtcNow.Date;

            // hôm qua 00:00 (UTC)
            var yesterday = today.AddDays(-1);
            

            // ngày mai 00:00 (UTC)
            var tomorrow = today.AddDays(1);

            // Lấy CreatedAt >= hôm qua và < ngày mai
            var filter = $"&$filter=CreatedAt ge {yesterday:o} and CreatedAt lt {tomorrow:o}";

            var stadiums = await _service.SearchStadiumAsync(filter);


            return Content(stadiums, "application/json");
        }

        //Lấy dữ liệu để xuất file excel
        public async Task<IActionResult> GetStadiumsForExcel()
        {
   
            var stadiums = await _service.ExportExcel();
            return Content(stadiums, "application/json");
        }

        //lấy count của tất cả các loại thể thao
        public async Task<IActionResult> GetCourtTypes()
        {
            SportCountViewModel model = new SportCountViewModel();
            
            var badminton = await _service.GetSportType("Cầu lông");
            var tennis = await _service.GetSportType("Tennis");
            var basketball = await _service.GetSportType("Bóng rổ");
            var volleyball = await _service.GetSportType("Bóng chuyền");
            var football = await _service.GetSportType("Bóng đá");
            var pickleball = await _service.GetSportType("Pickleball");
            model.volleyballCount = (int)volleyball.Count;
            model.basketballCount = (int)basketball.Count;
            model.tennisCount = (int)tennis.Count;
            model.badmintonCount = (int)badminton.Count;
            model.footballCount = (int)football.Count;
            model.pickleballCount = (int)pickleball.Count;
            return Json(model);
        }

        // Lấy nhà thi đấu chưa duyệt
        public async Task<IActionResult> GetUnapprovedStadiums()
        { 
            var stadiums = await _service.GetUnapprovedStadiums();
            return Json(stadiums);
        }

        // Lấy tổng số nhà thi đấu
        public async Task<IActionResult> GetTotalStadiums()
        {
            var stadiums = await _service.GetTotalStadiums();
            return Json(stadiums);
        }

        // lấy nhà thi đấu theo các năm đăng ký
        public async Task<IActionResult> GetStadiumsByYear(int year)
        {
            // Lọc các sân được tạo trong năm cụ thể
            var filter = $"&$filter=year(CreatedAt) eq {year}";
            var stadiums = await _service.SearchStadiumAsync(filter);
            return Content(stadiums, "application/json");
        }
        // lấy nhà thi đấu theo các tháng đăng ký trong năm hiện tại
        public async Task<IActionResult> GetStadiumsByMonth(int month)
        {
            var currentYear = DateTime.UtcNow.Year;
            // Lọc các sân được tạo trong tháng cụ thể của năm hiện tại
            var filter = $"&$filter=year(CreatedAt) eq {currentYear} and month(CreatedAt) eq {month}";
            var stadiums = await _service.SearchStadiumAsync(filter);
            return Content(stadiums, "application/json");
        }


    }
}
