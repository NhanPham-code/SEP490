using FindTeamAPI.DTOs;
using FindTeamAPI.Service.Interface;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> CreateTeamPost([FromBody] CreateTeamPostDTO createTeamPostDTO)
        {
            if (createTeamPostDTO == null)
            {
                return BadRequest("Invalid team post data.");
            }
            var createdPost = await _teamPostService.CreateTeamPostAsync(createTeamPostDTO);
            return Ok(createdPost);
        }

        [HttpPut("UpdateTeamPost")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> UpdateTeamPost([FromBody] UpdateTeamPostDTO updateTeamPostDTO)
        {
            if (updateTeamPostDTO == null)
            {
                return BadRequest("Invalid team post data.");
            }
            var updatedPost = await _teamPostService.UpdateTeamPostAsync(updateTeamPostDTO);
            return Ok(updatedPost);
        }

        [HttpDelete("DeleteTeamPost")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteTeamPost([FromQuery] int postId)
        {
            var result = await _teamPostService.DeleteTeamPostAsync(postId);
            if (result)
            {
                return Ok(true);
            }
            return NotFound("Team post not found or you are not authorized to delete this post.");
        }

    }
}
