using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace AdminUI.Controllers
{
    public class CourtController : Controller
    {
        private readonly ICourtService _courtService;
        private readonly ICourtRelationService _courtRelationService;

        public CourtController(ICourtService courtService, ICourtRelationService courtRelationService)
        {
            _courtService = courtService;
            _courtRelationService = courtRelationService;
        }
        public IActionResult CourtAdmin()
        {
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

        public async Task<IActionResult> GetAllCourtRelationsByParentId(int parentId)
        {
            var courtRelations = await _courtRelationService.GetAllCourtRelationByParentId(parentId);
            return Json(courtRelations);
        }

        public async Task<IActionResult> GetAllCourtRelationsByChildId(int childId)
        {
            var courtRelations = await _courtRelationService.GetAllCourtRelationBychildId(childId);
            return Json(courtRelations);
        }


    }
}
