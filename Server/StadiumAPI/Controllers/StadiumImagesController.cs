using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StadiumAPI.DTOs;
using StadiumAPI.Service.Interface;

namespace StadiumAPI.Controllers
{
    public class StadiumImagesController : ControllerBase
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

        [HttpPost]
        [Route("/api/AddStadiumImages")]
        [Consumes("multipart/form-data")]
        [Authorize(Roles = ("StadiumManager"))]
        public async Task<IActionResult> AddImages([FromForm] List<CreateStadiumImageDTO> imagesDto)
        {
            if (imagesDto == null || !imagesDto.Any() || imagesDto.Any(dto => dto.ImageUrl == null))
                return BadRequest("At least one image file is required.");

            var uploadsFolder = Path.Combine(_env.WebRootPath, "img");
            Directory.CreateDirectory(uploadsFolder); // Creates directory if it doesn't exist

            var createdImages = new List<ReadStadiumImageDTO>();

            try
            {
                foreach (var imageDto in imagesDto)
                {
                    if (imageDto.ImageUrl == null || imageDto.ImageUrl.Length == 0)
                        continue;
                    var uniqueFileName = string.Empty;
                    do
                    {
                        uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageDto.ImageUrl.FileName)}";
                    } while (System.IO.File.Exists(Path.Combine(uploadsFolder, uniqueFileName)));
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageDto.ImageUrl.CopyToAsync(stream);
                    }

                    var createdImage = await _serviceStadiumImage.AddImageAsync(imageDto, $"img/{uniqueFileName}");
                    createdImages.Add(createdImage);
                }

                return Ok(createdImages);
            }
            catch (Exception ex)
            {
                // Log the exception (implement proper logging)
                return StatusCode(500, "An error occurred while uploading images.");
            }
        }

        // PUT: api/StadiumImages/{id}
        [HttpPut]
        [Route("api/UpdateStadiumImage")]
        [Consumes("multipart/form-data")]
        [Authorize(Roles = ("StadiumManager"))]
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
                if (System.IO.File.Exists(oldFilePath))
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
        [HttpDelete]
        [Route("api/DeleteStadiumImage")]
        [Authorize(Roles = ("StadiumManager"))]
        public async Task<IActionResult> DeleteImages([FromQuery] int stadiumId)
        {
            var images = (await _serviceStadiumImage.GetAllImagesAsync(stadiumId)).ToList();

            if (images == null || !images.Any())
            {
                return Ok(true);
            }

            bool allDeleted = true;

            foreach (var img in images)
            {
                var isDeleted = await _serviceStadiumImage.DeleteImageByStadiumIdAsync(img.Id);
                if (isDeleted)
                {
                    // Xóa file vật lý
                    var filePath = Path.Combine(
                        _env.WebRootPath,
                        img.ImageUrl.TrimStart('/', '\\') // loại bỏ dấu / hoặc \ ở đầu nếu có
                    );

                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                else
                {
                    allDeleted = false;
                }
            }

            if (!allDeleted)
            {
                return BadRequest("Some images could not be deleted.");
            }

            return Ok(new { success = true });
        }

        [HttpDelete]
        [Route("api/DeleteImagesByImgId")]
        [Authorize(Roles = ("StadiumManager"))]
        public async Task<IActionResult> DeleteImagesByImgId([FromBody] int[] id)
        {
            if (id == null || id.Length == 0)
                return BadRequest("No ids provided.");

            var images = new List<ReadStadiumImageDTO>();
            foreach (var imgId in id)
            {
                var img = await _serviceStadiumImage.GetImageByIdAsync(imgId);
                if (img != null)
                    images.Add(img);
            }

            if (!images.Any())
                return NotFound("No images found for this stadium.");

            var isDeleted = await _serviceStadiumImage.DeleteImageAsync(images);
            if (!isDeleted)
                return BadRequest("Some images could not be deleted.");

            foreach (var img in images)
            {
                var filePath = Path.Combine(
                    _env.WebRootPath,
                    img.ImageUrl.TrimStart('/', '\\')
                );
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }

            return Ok(true);
        }
    }
}