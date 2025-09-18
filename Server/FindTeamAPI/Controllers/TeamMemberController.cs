using FindTeamAPI.DTOs;
using FindTeamAPI.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindTeamAPI.Controllers
{
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberService _teamMemberService;
        public TeamMemberController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }

        [HttpGet]
        [Route("GetAllTeamMember")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetAllTeamMemberByTeamPost([FromQuery]int postId)
        {
            
            return Ok((await _teamMemberService.GetAllTeamMembersAsync(postId)).ToList());
        }
        [HttpGet]
        [Route("GetTeamMemberByPostIdAndId")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> GetTeamMemberByIdTeam([FromQuery] int teamId, [FromQuery] int postId)
        {
            var team = await _teamMemberService.GetTeamMemberByIdAsync(teamId, postId);
            return Ok(team);
        }

        [HttpPost]
        [Route("AddNewTeamMember")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddTeamMember([FromBody] CreateTeamMemberDTO createTeamMemberDTO)
        {
            var member = await _teamMemberService.CreateTeamMemberAsync(createTeamMemberDTO);
            return Ok(member);
        }

        [HttpPut]
        [Route("UpdateTeamMember")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> UpdateTeamMember(UpdateTeamMemberDTO updateTeamMemberDTO)
        {
            var teamMemberUpdate = await _teamMemberService.UpdateTeamMemberAsync(updateTeamMemberDTO);
            return Ok(teamMemberUpdate);
        }

        [HttpDelete]
        [Route("DeleteTeamMember")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteTeamMember([FromQuery]int teamMemberId, [FromQuery] int postId)
        {
            return Ok(await _teamMemberService.DeleteTeamMemberAsync(teamMemberId, postId));
        }

    }
}
