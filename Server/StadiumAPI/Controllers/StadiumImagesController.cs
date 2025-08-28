using Microsoft.AspNetCore.Mvc;
using StadiumAPI.DTOs;
using StadiumAPI.Service.Interface;

namespace StadiumAPI.Controllers
{
    public class StadiumImagesController : Controller
    {
        private readonly IStadiumImagesService _serviceStadiumImage;
        private readonly IWebHostEnvironment _env;

        public StadiumImagesController(IStadiumImagesService serviceStadiumImage, IWebHostEnvironment env)
        {
            _serviceStadiumImage = serviceStadiumImage;
            _env = env;
        }

        // GET: api/StadiumImages/{stadiumId}
        [HttpGet]
        [Route("api/AllStadiumImages")]
        public async Task<IActionResult> GetAllImages([FromQuery] int stadiumId)
        {
            var images = await _serviceStadiumImage.GetAllImagesAsync(stadiumId);
            if (images == null || !images.Any())
            {
                return NotFound("No images found for the specified stadium.");
            }
            return Ok(images);
        }

        // POST: api/StadiumImages
        [HttpPost]
        [Route("api/AddStadiumImages")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddImage([FromForm] CreateStadiumImageDTO imageDto)
        {
            if (imageDto.ImageUrl == null || imageDto.ImageUrl.Length == 0)
                return BadRequest("Image file is required.");

            var uploadsFolder = Path.Combine(_env.WebRootPath, "img");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageDto.ImageUrl.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageDto.ImageUrl.CopyToAsync(stream);
            }

            var createdImage = await _serviceStadiumImage.AddImageAsync(imageDto, $"img/{uniqueFileName}");
            return Ok(createdImage);
        }

        // PUT: api/StadiumImages/{id}
        [HttpPut]
        [Route("api/UpdateStadiumImage")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateImage([FromQuery] int id, [FromForm] UpdateStadiumImageDTO imageDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existingImage = await _serviceStadiumImage.GetImageByIdAsync(imageDto.Id);
            var uniqueFileName = string.Empty;
            var newImageURL = string.Empty;
            if (imageDto.ImageUrl != null && imageDto.ImageUrl.Length > 0)
            {
                var adminfolderPath = Path.Combine(_env.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageDto.ImageUrl.FileName);
                var adminFilePath = Path.Combine(adminfolderPath, uniqueFileName);
                newImageURL = $"img/{uniqueFileName}";
                Directory.CreateDirectory(adminfolderPath);

                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingImage.ImageUrl);
                if (System.IO.File.Exists(oldFilePath) && existingImage.ImageUrl != newImageURL)
                {
                    System.IO.File.Delete(oldFilePath);
                }
                using (var stream = new FileStream(adminFilePath, FileMode.Create))
                {
                    await imageDto.ImageUrl.CopyToAsync(stream);
                }
            }
            else
            {
                if (existingImage != null)
                {
                    uniqueFileName = existingImage.ImageUrl;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Product not found.");
                    return BadRequest();
                }
            }

            var updatedImage = await _serviceStadiumImage.UpdateImageAsync(id, imageDto, newImageURL);
            return Ok(updatedImage);
        }

        // DELETE: api/StadiumImages/{id}
        [HttpDelete("DeleteStadiumImage")]
        public async Task<IActionResult> DeleteImage([FromQuery] int id)
        {
            var image = (await _serviceStadiumImage.GetAllImagesAsync(id)).ToList();
            if (image == null)
            {
                return NotFound("Image not found.");
            }
            var isDeleted = await _serviceStadiumImage.DeleteImageAsync(id);
            if (!isDeleted)
            {
                return BadRequest("Failed to delete the image.");
            }
            // Optionally, delete the file from the server
            foreach (var img in image)
            {
                // Ghép path tuyệt đối trong wwwroot/images
                var filePath = Path.Combine(_env.WebRootPath, img.ImageUrl);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            return Ok(true);
        }
    }
}