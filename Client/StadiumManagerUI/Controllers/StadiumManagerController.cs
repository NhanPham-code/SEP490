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
        public CreateStadiumDTO createStadiumDTO { get; set; } = new CreateStadiumDTO();

        [BindProperty]
        public CreateStadiumImageDTO createStadiumImageDTO { get; set; } = new CreateStadiumImageDTO();

        [BindProperty]
        public UpdateStadiumDTO updateStadiumDTO { get; set; } = new UpdateStadiumDTO();

        [BindProperty]
        public UpdateStadiumImageDTO updateStadiumImageDTO { get; set; } = new UpdateStadiumImageDTO();

        [BindProperty]
        public CreateStadiumRequest CreateStadiumRequest { get; set; } = new CreateStadiumRequest();

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
            CreateStadiumRequest.StadiumImage.StadiumId = stadium.Id;
            var image = await _imageService.AddStadiumImageAsync(CreateStadiumRequest.StadiumImage);
            if (stadium != null)
            {
                return RedirectToAction("Stadium");
            }

            return View(stadium);
        }

        public async Task<IActionResult> DeleteStadium(int id)
        {
            var stadium = await _service.DeleteStadiumAsync(id);
            var image = await _imageService.DeleteStadiumImageAsync(id);

            if (!stadium)
            {
                return RedirectToAction("Stadium");
            }
            return View(stadium);
        }
    }
}