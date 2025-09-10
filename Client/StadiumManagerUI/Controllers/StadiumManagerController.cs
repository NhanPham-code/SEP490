using DTOs.StadiumDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Security.Policy;
using System.Threading.Tasks;

namespace StadiumManagerUI.Controllers
{
    public class StadiumManagerController : Controller
    {
        private readonly IStadiumService _service;
        private readonly IStadiumImageService _imageService;
        private readonly IStadiumVideoSetvice _videoService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        [BindProperty]
        public CreateStadiumRequest CreateStadiumRequest { get; set; } = new CreateStadiumRequest();

        [BindProperty]
        public UpdateStadiumRequest updateStadiumRequest { get; set; } = new UpdateStadiumRequest();

        public StadiumManagerController(IStadiumService service, IStadiumImageService imageService,
            IStadiumVideoSetvice videoService, ITokenService tokenService, IUserService userService)
        {
            _service = service;
            _imageService = imageService;
            _videoService = videoService;
            _tokenService = tokenService;
            _userService = userService;
        }

        public IActionResult Stadium()
        {
            var token = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Common");
            }
            return View();
        }

        public async Task<IActionResult> GetAllAndSearch(string url)
        {
            var token = _tokenService.GetAccessTokenFromCookie();
            var userId = await _userService.GetMyProfileAsync(token);
            url += $" CreatedBy eq {userId.UserId}";
            var stadium = await _service.SearchStadiumAsync(url);
            return Content(stadium, "application/json");
        }

        public async Task<IActionResult> CreateNewStadium()
        {
            var token = _tokenService.GetAccessTokenFromCookie();
            var userId = await _userService.GetMyProfileAsync(token);
            CreateStadiumRequest.Stadium.CreatedBy = userId.UserId;
            if (CreateStadiumRequest.StadiumImage == null)
            {
                return Json(new { success = 400 });
            }
            var stadium = await _service.CreateStadiumAsync(CreateStadiumRequest.Stadium);

            if (stadium == null)
            {
                return RedirectToAction("Stadium");
            }
            else
            {
                if (CreateStadiumRequest.StadiumImage != null)
                {
                    foreach (var imageDto in CreateStadiumRequest.StadiumImage)
                    {
                        imageDto.StadiumId = stadium.Id; // Gán đúng ID đã tạo
                    }
                    var image = await _imageService.AddStadiumImageAsync(CreateStadiumRequest.StadiumImage);
                }

                if (CreateStadiumRequest.StadiumVideo != null)
                {
                    foreach (var imageDto in CreateStadiumRequest.StadiumVideo)
                    {
                        imageDto.StadiumId = stadium.Id; // Gán đúng ID đã tạo
                    }
                    var video = await _videoService.AddStadiumVideoAsync(CreateStadiumRequest.StadiumVideo);
                }
            }

            return Json(new { success = 200, value = stadium });
        }

        public async Task<IActionResult> UpdateStadium()
        {
            var token = _tokenService.GetAccessTokenFromCookie();
            var userId = await _userService.GetMyProfileAsync(token);
            updateStadiumRequest.Stadium.CreatedBy = userId.UserId;
            updateStadiumRequest.Stadium.IsLocked = false;
            var stadium = await _service.UpdateStadiumAsync(updateStadiumRequest.Stadium.Id, updateStadiumRequest.Stadium);
            bool check = false;
            if (stadium == null)
            {
                return Json(new { success = 400, value = stadium });
            }
            else
            {
                if (updateStadiumRequest.StadiumImage.Any())
                {
                    foreach (var imageDto in updateStadiumRequest.StadiumImage)
                    {
                        imageDto.StadiumId = stadium.Id; // Gán đúng ID đã tạo
                    }
                    var image = await _imageService.AddStadiumImageAsync(updateStadiumRequest.StadiumImage);
                    if (image != null) check = true;
                }
                if (updateStadiumRequest.DeletedImageIds.Any())
                {
                    check = await _imageService.DeleteStadiumImageByIdAsync(updateStadiumRequest.DeletedImageIds);
                }
                if (updateStadiumRequest.StadiumVideo.Any())
                {
                    foreach (var imageDto in updateStadiumRequest.StadiumVideo)
                    {
                        imageDto.StadiumId = stadium.Id; // Gán đúng ID đã tạo
                    }
                    var image = await _videoService.AddStadiumVideoAsync(updateStadiumRequest.StadiumVideo);
                    if (image != null) check = true;
                }
                if (updateStadiumRequest.DeletedVideoIds.Any())
                {
                    check = await _videoService.DeleteStadiumVideoAsync(updateStadiumRequest.DeletedVideoIds);
                }
            }
            if (check)
                return Json(new { success = 200, value = stadium });
            else
                return Json(new { success = 400, value = stadium });
        }

        public async Task<IActionResult> DeleteStadium(int id)
        {
            
            var locked = await _service.DeleteStadiumAsync(id);

            if (locked)
            {
                return Json(new { success = 200, value = locked });
            }
            else
                return Json(new { success = 400, value = locked });
        }
    }
}