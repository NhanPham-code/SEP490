using Microsoft.AspNetCore.Mvc;
using StadiumEquipmentAPI.DTOs;
using StadiumEquipmentAPI.Service;

namespace StadiumEquipmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StadiumEquipmentAPIController : ControllerBase
    {
        private readonly IStadiumEquipmentService _service;

        public StadiumEquipmentAPIController(IStadiumEquipmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StadiumEquipmentResponse>>> GetAllEquipments()
        {
            try
            {
                var equipments = await _service.GetAllEquipmentsAsync();
                return Ok(equipments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StadiumEquipmentResponse>> GetEquipmentById(int id)
        {
            try
            {
                var equipment = await _service.GetEquipmentByIdAsync(id);
                if (equipment == null)
                    return NotFound($"Equipment with ID {id} not found");

                return Ok(equipment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("stadium/{stadiumId}")]
        public async Task<ActionResult<IEnumerable<StadiumEquipmentResponse>>> GetEquipmentsByStadiumId(int stadiumId)
        {
            try
            {
                var equipments = await _service.GetEquipmentsByStadiumIdAsync(stadiumId);
                return Ok(equipments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<StadiumEquipmentResponse>> CreateEquipment([FromForm] CreateStadiumEquipment createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var equipment = await _service.CreateEquipmentAsync(createDto);
                return CreatedAtAction(nameof(GetEquipmentById), new { id = equipment.Id }, equipment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<StadiumEquipmentResponse>> UpdateEquipment(int id, [FromForm] UpdateStadiumEquipment updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var equipment = await _service.UpdateEquipmentAsync(id, updateDto);
                if (equipment == null)
                    return NotFound($"Equipment with ID {id} not found");

                return Ok(equipment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEquipment(int id)
        {
            try
            {
                var deleted = await _service.DeleteEquipmentAsync(id);
                if (!deleted)
                    return NotFound($"Equipment with ID {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("image/{filename}")]
        public IActionResult GetImage(string filename)
        {
            try
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "stadium-equipments", filename);

                if (!System.IO.File.Exists(imagePath))
                    return NotFound("Image not found");

                var image = System.IO.File.OpenRead(imagePath);
                var mimeType = GetMimeType(filename);

                return File(image, mimeType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving image: {ex.Message}");
            }
        }

        private string GetMimeType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                _ => "application/octet-stream"
            };
        }
    }
}