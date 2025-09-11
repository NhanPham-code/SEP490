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

        // OData-enabled GET
        [HttpGet]
        [EnableQuery]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var result = await _service.GetByCodeAsync(code);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // New endpoint to get discounts by a specific stadium ID
        [HttpGet("stadium/{stadiumId}")]
        [EnableQuery]
        public IActionResult GetByStadiumId(int stadiumId)
        {
            var result = _service.GetByStadiumId(stadiumId);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "StadiumManager,Admin")] // Chỉ StadiumManager hoặc Admin được truy cập
        public async Task<IActionResult> Create([FromBody] CreateDiscountDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _service.CreateAsync(dto);
                // Trả về 201 Created và cung cấp URL để truy cập resource mới tạo
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Authorize(Roles = "StadiumManager,Admin")] // Chỉ StadiumManager hoặc Admin được truy cập
        public async Task<IActionResult> Update([FromBody] UpdateDiscountDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

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
    }
}