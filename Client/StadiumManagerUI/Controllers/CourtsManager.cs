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

        [Route("CourtsManager/CourtManager")]
        public IActionResult CourtManager()
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

        [BindProperty]
        public CourtsRelationRe7[] court7Relations { get; set; }

        public async Task<IActionResult> CreateCourtRelation(int courtParentId, int[] courtChildId)
        {
            try
            {
                // 1. Tạo quan hệ chính (sân cha -> sân con)
                var createdCourtRelation = await _courtRelationService.CreateCourtRelation(courtChildId, courtParentId);

                // Kiểm tra lỗi cho quan hệ chính
                foreach (var item in createdCourtRelation)
                {
                    if (item.ChildCourtId == courtParentId)
                    {
                        return Json(new { success = 400, value = $"Sân này đã được đặt làm con của {item.ChildCourt.Name}" });
                    }
                }

                // 2. Tạo quan hệ phụ (sân 7 -> sân 5) nếu có
                if (court7Relations.Any() && court7Relations.Length > 0)
                {
                    for (int i = 0; i < court7Relations.Length; i++)
                    {
                        var court7Relation = court7Relations[i];

                        // Kiểm tra xem parentCourtId có tồn tại trong courtChildId không
                        if (courtChildId.Contains(court7Relation.parentCourtId))
                        {
                            // Tạo quan hệ sân 7 -> sân 5
                            var relation7 = await _courtRelationService.CreateCourtRelation(
                                court7Relation.childCourtIds,
                                court7Relation.parentCourtId
                            );
                            var relation11 = await _courtRelationService.CreateCourtRelation(
                                court7Relation.childCourtIds,
                                courtParentId
                            );

                            // Kiểm tra lỗi cho quan hệ phụ
                            foreach (var item in relation7)
                            {
                                if (item.ChildCourtId == court7Relation.parentCourtId)
                                {
                                    return Json(new { success = 400, value = $"Sân 7 này đã được đặt làm con của {item.ChildCourt.Name}" });
                                }
                            }
                        }
                    }
                }

                return Json(new { success = 200, value = createdCourtRelation });
            }
            catch (Exception ex)
            {
                return Json(new { success = 500, value = $"Lỗi khi tạo quan hệ sân: {ex.Message}" });
            }
        }

        public async Task<IActionResult> UpdateCourtRelation(int courtParentId, int[] courtChildId)
        {
            try
            {
                bool oneCourt = true;
                // 1. Xóa các quan hệ cũ
                var delete = await _courtRelationService.DeleteCourtRelation(courtParentId);
                // 2. Tạo lại quan hệ chính
                if (courtChildId.Length > 0 && courtChildId != null)
                {
                    var updatedCourtRelation = await _courtRelationService.CreateCourtRelation(courtChildId, courtParentId);
                }

                // 3. Tạo lại quan hệ phụ (sân 7 -> sân 5) nếu có
                if (court7Relations.Any() && court7Relations.Length > 0)
                {
                    
                    for (int i = 0; i < court7Relations.Length; i++)
                    {
                        
                        var court7Relation = court7Relations[i];

                        //if (court7Relation.childCourtIds.Any() == false)
                        //{
                        //    var delete7 = await _courtRelationService.DeleteCourtRelation(court7Relation.parentCourtId);
                        //}
                        oneCourt = false;
                        if (courtChildId.Contains(court7Relation.parentCourtId))
                        {
                            // Xóa quan hệ cũ của sân 7
                            await _courtRelationService.DeleteCourtRelation(court7Relation.parentCourtId);

                            // Tạo quan hệ mới sân 7 -> sân 5
                            await _courtRelationService.CreateCourtRelation(
                                court7Relation.childCourtIds,
                                court7Relation.parentCourtId
                            );
                            await _courtRelationService.CreateCourtRelation(
                                court7Relation.childCourtIds,
                                courtParentId
                            );
                        }
                    }
                } 
                if (oneCourt)
                {
                    var delete7 = await _courtRelationService.DeleteCourtRelation(courtChildId[0]);
                }

                    return Json(new { success = 200, value = delete });
            }
            catch (Exception ex)
            {
                return Json(new { success = 500, value = $"Lỗi khi cập nhật quan hệ sân: {ex.Message}" });
            }
        }

        public async Task<IActionResult> DeleteCourt([FromQuery]int id)
        {
            var result = await _courtService.DeleteCourtAsync(id);

            return Json(result);
        }
    }
}