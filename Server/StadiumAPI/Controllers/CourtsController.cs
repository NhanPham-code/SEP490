using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StadiumAPI.DTOs;
using StadiumAPI.Service.Interface;

namespace StadiumAPI.Controllers
{
    public class CourtsController : Controller
    {
        private readonly ICourtsService _courtsService;

        public CourtsController(ICourtsService courtsService)
        {
            _courtsService = courtsService ?? throw new ArgumentNullException(nameof(courtsService));
        }

        /// GET: api/courts/{stadiumId}
        ///

        [HttpGet("api/courtsByStadiumId")]
        public async Task<IActionResult> GetAllCourts(int stadiumId)
        {
            if (stadiumId <= 0)
            {
                return BadRequest("Stadium ID must be greater than zero.");
            }
            var courts = await _courtsService.GetAllCourtsAsync(stadiumId);
            return Ok(courts);
        }

        // GET:
        [HttpGet("GetCourtAndCourtRealation")]
        public async Task<IActionResult> GetCourtAndCourtRealation(int stadiumId)
        {
            var results = await _courtsService.GetCourtAndCourtRelation(stadiumId);
            return Ok(results);
        }

        /// GET: api/courts/{id}
        ///

        [HttpGet("api/courtsById")]
        public async Task<IActionResult> GetCourtById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Court ID must be greater than zero.");
            }
            var court = await _courtsService.GetCourtByIdAsync(id);
            if (court == null)
            {
                return NotFound();
            }
            return Ok(court);
        }

        /// POST: api/courts
        ///

        [HttpPost("api/courts")]
        [Authorize(Roles = ("StadiumManager"))]
        public async Task<IActionResult> CreateCourt([FromBody] CreateCourtDTO createCourtDTO)
        {
            if (createCourtDTO == null)
            {
                return BadRequest("Court data is required.");
            }
            var createdCourt = await _courtsService.CreateCourtAsync(createCourtDTO);
            return CreatedAtAction(nameof(GetCourtById), new { id = createdCourt.Id }, createdCourt);
        }

        /// PUT: api/courts/{id}
        ///

        [HttpPut("api/courts")]
        [Authorize(Roles = ("StadiumManager"))]
        public async Task<IActionResult> UpdateCourt(int id, [FromBody] UpdateCourtDTO updateCourtDTO)
        {
            if (updateCourtDTO == null || id <= 0)
            {
                return BadRequest("Invalid court data or ID.");
            }
            var updatedCourt = await _courtsService.UpdateCourtAsync(id, updateCourtDTO);
            if (updatedCourt == null)
            {
                return NotFound();
            }
            return Ok(updatedCourt);
        }

        /// DELETE: api/courts/{id}
        ///

        [HttpDelete("api/courts")]
        [Authorize(Roles = ("StadiumManager"))]
        public async Task<IActionResult> DeleteCourt(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Court ID must be greater than zero.");
            }
            var result = await _courtsService.DeleteCourtAsync(id);
            if (!result)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}