using FeedbackAPI.DTOs;
using FeedbackAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace FeedbackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lấy danh sách feedback với OData query (filter, select, orderby...)
        /// </summary>
        [HttpGet]
        [EnableQuery]
        public IQueryable<FeedbackResponse> GetAll()
        {
            return _service.GetAllAsQueryable();
        }

        /// <summary>
        /// Lấy feedback theo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var feedback = await _service.GetByIdAsync(id);
            if (feedback == null)
                return NotFound();
            return Ok(feedback);
        }

        /// <summary>
        /// Tạo feedback mới (cho phép upload ảnh)
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Create([FromForm] CreateFeedback dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Cập nhật feedback (có thể cập nhật ảnh hoặc giữ nguyên)
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] UpdateFeedback dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return Ok(new { message = "Updated successfully" });
        }

        /// <summary>
        /// Xóa feedback
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return Ok(new { message = "Deleted successfully" });
        }

        /// <summary>
        /// Lấy feedback theo StadiumId
        /// </summary>
        [HttpGet("stadium/{stadiumId}")]
        public async Task<IActionResult> GetByStadiumId(int stadiumId)
        {
            var feedbacks = await _service.GetByStadiumIdAsync(stadiumId);
            return Ok(feedbacks);
        }
    }
}
