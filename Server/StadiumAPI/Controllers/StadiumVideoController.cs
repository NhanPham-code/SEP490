using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StadiumAPI.DTOs;
using StadiumAPI.Service.Interface;

namespace StadiumAPI.Controllers
{
    public class StadiumVideoController : ControllerBase
    {
        private readonly IStadiumVideosService _serviceStadiumVideo;
        private readonly IWebHostEnvironment _env;

        public StadiumVideoController(IStadiumVideosService serviceStadiumVideo, IWebHostEnvironment env)
        {
            _serviceStadiumVideo = serviceStadiumVideo;
            _env = env;
        }

        [HttpGet]
        [Route("api/AllStadiumVideos")]
        public async Task<IActionResult> GetAllVideos([FromQuery] int stadiumId)
        {
            var videos = await _serviceStadiumVideo.GetAllVideosAsync(stadiumId);
            if (videos == null || !videos.Any())
            {
                return NotFound("No videos found for the specified stadium.");
            }
            return Ok(videos);
        }

        [HttpGet]
        [Route("api/StadiumVideoById")]
        public async Task<IActionResult> GetVideoById([FromQuery] int id)
        {
            var video = await _serviceStadiumVideo.GetVideoByIdAsync(id);
            if (video == null)
            {
                return NotFound("No video found for the specified ID.");
            }
            return Ok(video);
        }

        [HttpPost("AddStadiumVideo")]
        [Consumes("multipart/form-data")]
        [Authorize(Roles = ("StadiumManager"))]
        public async Task<IActionResult> AddVideo([FromForm] List<CreateStadiumVideoDTO> createStadiumVideoDTO)
        {
            if (!createStadiumVideoDTO.Any() || createStadiumVideoDTO.Any(dto => dto.VideoUrl == null))
                return BadRequest("A video file is required.");

            var uploadsFolder = Path.Combine(_env.WebRootPath, "videos");
            Directory.CreateDirectory(uploadsFolder);
            var createdVideos = new List<ReadStadiumVideoDTO>();
            foreach (var videoDto in createStadiumVideoDTO)
            {
                if (videoDto.VideoUrl == null || videoDto.VideoUrl.Length == 0)
                    continue;

                var uniqueFileName = string.Empty;
                do
                {
                    uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(videoDto.VideoUrl.FileName)}";
                } while (System.IO.File.Exists(Path.Combine(uploadsFolder, uniqueFileName)));
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await videoDto.VideoUrl.CopyToAsync(stream);
                }
                createdVideos.Add(await _serviceStadiumVideo.AddVideoAsync(videoDto, $"videos/{uniqueFileName}"));
            }
            if (createdVideos == null)
            {
                return BadRequest("Video could not be created.");
            }

            return Ok(createdVideos);
        }

        [HttpDelete]
        [Route("/api/DeleteStadiumVideoById")]
        [Authorize(Roles = ("StadiumManager"))]
        public async Task<IActionResult> DeleteVideoById([FromBody] int[] id)
        {
            if (id == null || id.Length == 0)
                return BadRequest("No video IDs provided for deletion.");
            var video = new List<ReadStadiumVideoDTO>();
            for (int i = 0; i < id.Length; i++)
            {
                var vid = await _serviceStadiumVideo.GetVideoByIdAsync(id[i]);
                if (vid != null)
                    video.Add(new ReadStadiumVideoDTO
                    {
                        Id = vid.Id,
                        StadiumId = vid.StadiumId,
                        VideoUrl = vid.VideoUrl,
                        UploadedAt = vid.UploadedAt
                    });
            }
            if (video.Count == 0)
                return NotFound("No videos found for the specified IDs.");
            var isDeleted = await _serviceStadiumVideo.DeleteVideoAsync(video);
            bool allDeleted = true;
            foreach (var vid in video)
            {
                if (isDeleted)
                {
                    // Xóa file vật lý
                    var filePath = Path.Combine(
                        _env.WebRootPath,
                        vid.VideoUrl.TrimStart('/', '\\') // loại bỏ dấu / hoặc \ ở đầu nếu có
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
                return BadRequest("Some videos could not be deleted.");
            }
            return Ok(allDeleted);
        }

        [HttpDelete]
        [Route("/api/DeleteStadiumVideosByStadiumId")]
        [Authorize(Roles = ("StadiumManager"))]
        public async Task<IActionResult> DeleteVideosByStadiumId([FromQuery] int stadiumId)
        {
            var video = await _serviceStadiumVideo.GetAllVideosAsync(stadiumId);

            foreach (var vid in video)
            {
                // Xóa file vật lý
                var filePath = Path.Combine(
                    _env.WebRootPath,
                    vid.VideoUrl.TrimStart('/', '\\') // loại bỏ dấu / hoặc \ ở đầu nếu có
                );
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            var result = await _serviceStadiumVideo.DeleteVideoByStadiumIdAsync(stadiumId);
            if (!result)
                return NotFound("No videos found for the specified stadium ID.");
            return Ok(true);
        }
    }
}