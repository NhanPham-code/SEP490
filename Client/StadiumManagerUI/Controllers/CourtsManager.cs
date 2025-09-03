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

        public async Task<IActionResult> GetAllCourtRelationsByChildId(int childId)
        {
            var courtRelations = await _courtRelationService.GetAllCourtRelationBychildId(childId);
            return Json(courtRelations);
        }

        public async Task<IActionResult> CreateCourtRelation(int courtParentId, int[] courtChildId)
        {
            var createdCourtRelation = await _courtRelationService.CreateCourtRelation(courtChildId, courtParentId);
            foreach (var item in createdCourtRelation)
            {
                if (item.ChildCourtId == courtParentId)
                {
                    return Json(new { success = 400, value = $"Sân này đã được đặt làm con của {item.ChildCourt.Name}" });
                }
            }

            return Json(new { success = 200, value = createdCourtRelation });
        }

        public async Task<IActionResult> UpdateCourtRelation(int courtParentId, int[] courtChildId)
        {
            var updatedCourtRelation = Enumerable.Empty<ReadCourtRelationDTO>();
            var parentRelations = await _courtRelationService.GetAllCourtRelationByParentId(courtParentId);
            if (parentRelations.Count() < courtChildId.Length || parentRelations.Count() > courtChildId.Length)
            {
                var deleted = await _courtRelationService.DeleteCourtRelation(courtParentId);
                if (courtChildId.Length > 0)
                {
                    updatedCourtRelation = await _courtRelationService.CreateCourtRelation(courtChildId, courtParentId);
                }
            }
            else if (parentRelations.Count() == courtChildId.Length)
            {
                bool isSame = false;
                updatedCourtRelation = await _courtRelationService.UpdateCourtRelation(courtChildId, courtParentId);
                updatedCourtRelation.ToList().ForEach(cr =>
                {
                    if (cr.ChildCourtId == courtParentId)
                    {
                        isSame = true;
                    }
                });
                if (isSame)
                {
                    return Json(new { success = 400, value = $"Sân này đã được đặt làm con của {courtParentId}" });
                }
            }

            return Json(new { success = 200, value = updatedCourtRelation });
        }

        public async Task<IActionResult> DeleteCourt(int id)
        {
            await _courtRelationService.DeleteCourtRelation(id);
            var result = await _courtService.DeleteCourtAsync(id);

            return Json(result);
        }
    }
}