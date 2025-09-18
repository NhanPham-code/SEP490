using DiscountAPI.DTO;
using DiscountAPI.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace DiscountAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _service;

        public DiscountsController(IDiscountService service)
        {
            _service = service;
        }

        // REST GET all (không dùng OData, client chỉ nhận list JSON bình thường)
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll().ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var result = await _service.GetByCodeAsync(code);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("stadium/{stadiumId}")]
        public IActionResult GetByStadiumId(int stadiumId)
        {
            var result = _service.GetByStadiumId(stadiumId).ToList();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "StadiumManager,Admin")]
        public async Task<IActionResult> Create([FromBody] CreateDiscountDTO dto)
        {
            try
            {
                var result = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Authorize(Roles = "StadiumManager,Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateDiscountDTO dto)
        {
            try
            {
                await _service.UpdateAsync(dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "StadiumManager,Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
