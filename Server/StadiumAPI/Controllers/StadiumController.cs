using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StadiumAPI.Data;
using StadiumAPI.DTOs;
using StadiumAPI.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StadiumAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IServiceStadium _serviceStadium;

        public StadiumController(IServiceStadium serviceStadium)
        {
            _serviceStadium = serviceStadium;
        }

        // GET: api/ReadStadiumDTOes
        [HttpGet]
        [Route("GetAllStadium")]
        public async Task<ActionResult<IEnumerable<ReadStadiumDTO>>> GetReadStadiumDTO()
        {
            var readStadiumDTOs = await _serviceStadium.GetAllStadiumsAsync();
            return Ok(readStadiumDTOs);
        }

        // GET: api/ReadStadiumDTOes/5
        [HttpGet]
        public async Task<ActionResult<ReadStadiumDTO>> GetReadStadiumDTO([FromQuery] int id)
        {
            var readStadiumDTO = await _serviceStadium.GetStadiumByIdAsync(id);

            if (readStadiumDTO == null)
            {
                return NotFound();
            }

            return Ok(readStadiumDTO);
        }

        // PUT: api/ReadStadiumDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutReadStadiumDTO([FromQuery] int id, [FromBody] UpdateStadiumDTO updateStadiumDTO)
        {
            if (id != updateStadiumDTO.Id)
            {
                return BadRequest();
            }

            var update = await _serviceStadium.GetStadiumByIdAsync(id);

            if (update == null)
            {
                return NotFound();
            }
            updateStadiumDTO.NameUnsigned = RemoveDiacritics(updateStadiumDTO.Name).ToLower();
            updateStadiumDTO.AddressUnsigned = RemoveDiacritics(updateStadiumDTO.Address).ToLower();

            update = await _serviceStadium.UpdateStadiumAsync(id, updateStadiumDTO);

            return Ok(update);
        }

        // POST: api/ReadStadiumDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReadStadiumDTO>> PostReadStadiumDTO([FromBody] CreateStadiumDTO createStadiumDTO)
        {
            createStadiumDTO.NameUnsigned = RemoveDiacritics(createStadiumDTO.Name).ToLower();
            createStadiumDTO.AddressUnsigned = RemoveDiacritics(createStadiumDTO.Address).ToLower();

            var createdStadium = await _serviceStadium.CreateStadiumAsync(createStadiumDTO);

            return Ok(createdStadium);
        }

        // DELETE: api/ReadStadiumDTOes/5
        [HttpDelete]
        public async Task<IActionResult> DeleteReadStadiumDTO([FromQuery] int id)
        {
            var readStadiumDTO = await _serviceStadium.GetStadiumByIdAsync(id);
            if (readStadiumDTO == null)
            {
                return NotFound();
            }

            return Ok(await _serviceStadium.DeleteStadiumAsync(id));
        }

        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            // Normalize thành dạng Decomposed
            string normalized = text.Normalize(NormalizationForm.FormD);

            // Loại bỏ ký tự dấu
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string noDiacritics = regex.Replace(normalized, string.Empty);

            // Đổi đ -> d
            noDiacritics = noDiacritics.Replace('đ', 'd').Replace('Đ', 'D');

            return noDiacritics;
        }
    }
}