using FindTeamAPI.DTOs;
using FindTeamAPI.Service.Interface;
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
        public async Task<IActionResult> GetAllTeamMemberByTeamPost([FromQuery]int postId)
        {
            
            return Ok((await _teamMemberService.GetAllTeamMembersAsync(postId)).ToList());
        }
        [HttpGet]
        [Route("GetTeamMemberByPostId")]
        public async Task<IActionResult> GetTeamMemberByIdTeam([FromQuery] int teamId, [FromQuery] int postId)
        {
            var team = await _teamMemberService.GetTeamMemberByIdAsync(teamId, postId);
            return Ok(team);
        }

        [HttpPost]
        [Route("AddNewTeamMember")]
        public async Task<IActionResult> AddTeamMember(CreateTeamMemberDTO createTeamMemberDTO)
        {
            var member = await _teamMemberService.CreateTeamMemberAsync(createTeamMemberDTO);
            return Ok(member);
        }

        [HttpPut]
        [Route("UpdateTeamMember")]
        public async Task<IActionResult> UpdateTeamMember(UpdateTeamMemberDTO updateTeamMemberDTO)
        {
            var teamMemberUpdate = await _teamMemberService.UpdateTeamMemberAsync(updateTeamMemberDTO);
            return Ok(teamMemberUpdate);
        }

        [HttpDelete]
        [Route("DeleteTeamMember")]
        public async Task<IActionResult> DeleteTeamMember([FromQuery]int teamMemberId, [FromQuery] int postId)
        {
            return Ok(await _teamMemberService.DeleteTeamMemberAsync(teamMemberId, postId));
        }

    }
}
