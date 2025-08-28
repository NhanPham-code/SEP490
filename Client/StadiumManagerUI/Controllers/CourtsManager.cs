using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

namespace StadiumManagerUI.Controllers
{
    public class CourtsManager : Controller
    {

        private readonly ICourtService _courtService;
        private readonly ICourtRelationService _courtRelationService;
        public CourtsManager(ICourtService courtService, ICourtRelationService courtRelationService)
        {
            _courtService = courtService;
            _courtRelationService = courtRelationService;
        }
        [Route("CourtsManager/CourtManager/{stadiumId}")]
        public IActionResult CourtManager(int stadiumId)
        {
            ViewBag.StadiumId = stadiumId;
            return View();
        }

        public async Task<IActionResult> GetAllCourts(int stadiumId)
        {
            var courts = await _courtService.GetAllCourtsAsync(stadiumId);
            return Json(courts);
        }

        public async Task<IActionResult> GetCourtById(int id)
        {
            var courtRelations = await _courtService.GetCourtByIdAsync(id);
            return Json(courtRelations);
        }
    }
}
