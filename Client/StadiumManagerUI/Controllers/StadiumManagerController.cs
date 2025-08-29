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

        [BindProperty]
        public CreateStadiumRequest CreateStadiumRequest { get; set; } = new CreateStadiumRequest();

        [BindProperty]
        public UpdateStadiumRequest UpdateStadiumRequest { get; set; } = new UpdateStadiumRequest();

        public StadiumManagerController(IStadiumService service, IStadiumImageService imageService)
        {
            _service = service;
            _imageService = imageService;
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
                var image = await _imageService.AddStadiumImageAsync(CreateStadiumRequest.StadiumImage);
            }

            return Json(new { success = 200, value = stadium });
        }

        public async Task<IActionResult> UpdateStadium()
        {
            UpdateStadiumRequest.Stadium.CreatedBy = 3;
            var stadium = await _service.UpdateStadiumAsync(UpdateStadiumRequest.Stadium.Id, UpdateStadiumRequest.Stadium);
            bool check = false;
            if (stadium == null)
            {
                return Json(new { success = 400, value = stadium });
            }
            else
            {
                if (UpdateStadiumRequest.StadiumImage.Any())
                {
                    foreach (var imageDto in UpdateStadiumRequest.StadiumImage)
                    {
                        imageDto.StadiumId = stadium.Id; // Gán đúng ID đã tạo
                    }
                    var image = await _imageService.AddStadiumImageAsync(UpdateStadiumRequest.StadiumImage);
                    if (image != null) check = true;
                }
                if (UpdateStadiumRequest.DeletedImageIds.Any())
                {
                    check = await _imageService.DeleteStadiumImageByIdAsync(UpdateStadiumRequest.DeletedImageIds);
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