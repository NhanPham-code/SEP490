using DTOs.StadiumDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

namespace StadiumManagerUI.Controllers
{
    public class StadiumManagerController : Controller
    {
        private readonly IStadiumService _service;
        private readonly IStadiumImageService _imageService;
        private readonly IStadiumVideoSetvice _videoService;

        [BindProperty]
        public CreateStadiumRequest CreateStadiumRequest { get; set; } = new CreateStadiumRequest();

        [BindProperty]
        public UpdateStadiumRequest updateStadiumRequest { get; set; } = new UpdateStadiumRequest();

        public StadiumManagerController(IStadiumService service, IStadiumImageService imageService, IStadiumVideoSetvice videoService)
        {
            _service = service;
            _imageService = imageService;
            _videoService = videoService;
        }

        public IActionResult Stadium()
        {
            return View();
        }

        public async Task<IActionResult> GetAllAndSearch(string url)
        {
            var stadium = await _service.SearchStadiumAsync(url);
            return Content(stadium, "application/json");
        }

        public async Task<IActionResult> CreateNewStadium()
        {
            CreateStadiumRequest.Stadium.CreatedBy = 3;
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
                foreach (var imageDto in CreateStadiumRequest.StadiumImage)
                {
                    imageDto.StadiumId = stadium.Id; // Gán đúng ID đã tạo
                }
                foreach (var imageDto in CreateStadiumRequest.StadiumVideo)
                {
                    imageDto.StadiumId = stadium.Id; // Gán đúng ID đã tạo
                }
                var image = await _imageService.AddStadiumImageAsync(CreateStadiumRequest.StadiumImage);
                var video = await _videoService.AddStadiumVideoAsync(CreateStadiumRequest.StadiumVideo);
            }

            return Json(new { success = 200, value = stadium });
        }

        public async Task<IActionResult> UpdateStadium()
        {
            updateStadiumRequest.Stadium.CreatedBy = 3;
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
            var image = await _imageService.DeleteStadiumImageAsync(id);
            var video = await _videoService.DeleteAllVideosByStadiumId(id);
            var stadium = await _service.DeleteStadiumAsync(id);

            if (stadium && image)
            {
                return Json(new { success = 200, value = stadium });
            }
            else
                return Json(new { success = 400, value = stadium });
        }
    }
}