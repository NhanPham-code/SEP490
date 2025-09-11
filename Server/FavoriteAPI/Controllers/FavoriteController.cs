using FavoriteAPI.DTOs;
using FavoriteAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoriteController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService ?? throw new ArgumentNullException(nameof(favoriteService));
        }

        [HttpGet]
        public IActionResult GetFavorites()
        {
            var favorites = _favoriteService.GetFavorites();
            return Ok(favorites);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] CreateFavoriteDTO createFavoriteDTO)
        {
            if (createFavoriteDTO == null)
            {
                return BadRequest("Favorite data is null.");
            }

            // check if favorite already exists
            var isExists = await _favoriteService.IsFavoriteExistsAsync(createFavoriteDTO.UserId, createFavoriteDTO.StadiumId);
            if (isExists)
            {
                return Conflict("Favorite already exists.");
            }

            var favorite = await _favoriteService.AddFavoriteAsync(createFavoriteDTO);
            return CreatedAtAction(nameof(GetFavorites), new { id = favorite.FavoriteId }, favorite);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            var isDeleted = await _favoriteService.DeleteFavoriteAsync(id);
            if (!isDeleted)
            {
                return NotFound("Favorite not found.");
            }
            return NoContent();
        }
    }
}
