using DTOs.StadiumDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using StadiumAPI.DTOs;
using System.Threading.Tasks;

namespace StadiumManagerUI.Controllers
{
    public class CourtsManager : Controller
    {
        private readonly ICourtService _courtService;
        private readonly ICourtRelationService _courtRelationService;

        [BindProperty]
        public CreateCourtDTO createCourtDTO { get; set; }

        [BindProperty]
        public CreateCourtRelationDTO createCourtRelationDTO { get; set; }

        [BindProperty]
        public UpdateCourtDTO updateCourtDTO { get; set; }

        [BindProperty]
        public UpdateCourtRelationDTO updateCourtRelationDTO { get; set; }

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

        public async Task<IActionResult> CreateCourt()
        {
            var createdCourt = await _courtService.CreateCourtAsync(createCourtDTO);
            return Json(createdCourt);
        }

        public async Task<IActionResult> UpdateCourt(int id)
        {
            var updatedCourt = await _courtService.UpdateCourtAsync(id, updateCourtDTO);
            return Json(updatedCourt);
        }

        public async Task<IActionResult> GetAllCourtRelationsByParentId(int parentId)
        {
            var courtRelations = await _courtRelationService.GetAllCourtRelationByParentId(parentId);
            return Json(courtRelations);
        }

        public async Task<IActionResult> CreateCourtRelation(int courtParentId, int[] courtChildId)
        {
            var createdCourtRelation = await _courtRelationService.CreateCourtRelation(courtChildId, courtParentId);
            return Json(createdCourtRelation);
        }

        public async Task<IActionResult> UpdateCourtRelation(int courtParentId, int[] courtChildId)
        {
            var updatedCourtRelation = await _courtRelationService.UpdateCourtRelation(courtChildId, courtParentId);
            return Json(updatedCourtRelation);
        }

        public async Task<IActionResult> DeleteCourt(int id)
        {
            var result = await _courtService.DeleteCourtAsync(id);
            return Json(result);
        }
    }
}