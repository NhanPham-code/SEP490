using FindTeamAPI.DTOs;
using FindTeamAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FindTeamAPI.Controllers
{
    public class TeamPostController : ControllerBase
    {
        private readonly ITeamPostService _teamPostService;
        public TeamPostController(ITeamPostService teamPostService)
        {
            _teamPostService = teamPostService;
        }

        [HttpPost("CreateTeamPost")]
        public async Task<IActionResult> CreateTeamPost([FromBody] CreateTeamPostDTO teamPost)
        {
            if (teamPost == null)
            {
                return BadRequest("Invalid team post data.");
            }
            var createdPost = await _teamPostService.CreateTeamPostAsync(teamPost);
            return Ok(createdPost);
        }

        [HttpPut("UpdateTeamPost")]
        public async Task<IActionResult> UpdateTeamPost([FromBody] UpdateTeamPostDTO teamPost)
        {
            if (teamPost == null)
            {
                return BadRequest("Invalid team post data.");
            }
            var updatedPost = await _teamPostService.UpdateTeamPostAsync(teamPost);
            return Ok(updatedPost);
        }

        [HttpDelete("DeleteTeamPost")]
        public async Task<IActionResult> DeleteTeamPost([FromQuery] int postId)
        {
            var result = await _teamPostService.DeleteTeamPostAsync(postId);
            if (result)
            {
                return NoContent();
            }
            return NotFound("Team post not found or you are not authorized to delete this post.");
        }

    }
}
