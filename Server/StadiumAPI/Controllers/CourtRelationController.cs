using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StadiumAPI.DTOs;
using StadiumAPI.Service.Interface;

namespace StadiumAPI.Controllers
{
    public class CourtRelationController : ControllerBase
    {
        private readonly ICourtRelationService _courtRelationService;

        public CourtRelationController(ICourtRelationService courtRelationService)
        {
            _courtRelationService = courtRelationService;
        }

        [HttpGet("GetAllCourtRelationParentId")]
        public async Task<IActionResult> GetAllCourtRelationByParentId([FromQuery] int parentId)
        {
            if (parentId <= 0)
            {
                return NotFound("ParentId is required.");
            }
            var a = await _courtRelationService.GetAllCourtRelationByParentId(parentId);
            return Ok(a);
        }

        [HttpGet("GetAllCourtRelationByChildId")]
        public async Task<IActionResult> GetAllCourtRelationByChildId([FromQuery] int childId)
        {
            var a = await _courtRelationService.GetAllCourtRelationByChildId(childId);
            return Ok(a);
        }

        [HttpPost("AddCourtRelation")]
        public async Task<IActionResult> CreateCourtRelation([FromBody] int[] childCourt, [FromQuery] int parentCourt)
        {
            var createCourtRelationDTOs = new List<CreateCourtRelationDTO>();
            for (int i = 0; i < childCourt.Length; i++)
            {
                createCourtRelationDTOs.Add(new CreateCourtRelationDTO
                {
                    ChildCourtId = childCourt[i],
                    ParentCourtId = parentCourt
                });
            }

            if (!childCourt.Any())
            {
                return BadRequest("ParentCourt already has relations. Use UpdateCourtRelation instead.");
            }

            for (int i = 0; i < childCourt.Length; i++)
            {
                var check = (await _courtRelationService.GetAllCourtRelationByChildId(parentCourt)).ToList();
                if (check.Any() && check[0].ParentCourtId == parentCourt)
                {
                    return Ok(check[i]);
                }
            }
            var result = Enumerable.Empty<ReadCourtRelationDTO>();
            // tạo quan hệ nếu chưa tồn tại
            result = await _courtRelationService.CreateCourtRelation(createCourtRelationDTOs);

            return Ok(result);
        }

        [HttpPut("UpdateCourtRelation")]
        public async Task<IActionResult> UpdateCourtRelation([FromForm] int[] childCourt, [FromQuery] int parentId)
        {
            var court = (await _courtRelationService.GetAllCourtRelationByParentId(parentId)).ToArray();

            var updateCourtRelationDTOs = new List<UpdateCourtRelationDTO>();
            for (int i = 0; i < court.Length; i++)
            {
                var child = (await _courtRelationService.GetAllCourtRelationByChildId(childCourt[i])).ToList();
                updateCourtRelationDTOs.Add(new UpdateCourtRelationDTO
                {
                    Id = court[i].Id,
                    ChildCourtId = childCourt[i],
                    ParentCourtId = parentId
                });
                for (int j = 0; j < childCourt.Length; j++)
                {
                    if (child[i].ParentCourtId == childCourt[j] && child.Any())
                    {
                        return Ok(child[i]);
                    }
                }
            }

            var result = await _courtRelationService.UpdataCourtRelation(updateCourtRelationDTOs);
            return Ok(result);
        }

        [HttpDelete("DeleteCourtRelation")]
        public async Task<IActionResult> DeleteCourRelation([FromQuery] int parentId)
        {
            return Ok(await _courtRelationService.DeleteCourtRelationByParentId(parentId));
        }
    }
}