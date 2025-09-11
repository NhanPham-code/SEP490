using FindTeamAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Interfaces;

namespace CustomerUI.Controllers
{
    public class FindTeamController : Controller
    {

        private readonly ITeamPostService _teamPost;
        private readonly ITeamMemberService _teamMember;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private string token = string.Empty;
        public FindTeamController(ITeamPostService teamPost, ITeamMemberService teamMember, ITokenService tokenService, IUserService userService)
        {
            _teamPost = teamPost;
            _teamMember = teamMember;
            _tokenService = tokenService;
            _userService = userService;
     
        }

        public IActionResult FindTeam()
        {
            token = _tokenService.GetAccessTokenFromCookie();
            return View();
        }


        public async Task<IActionResult> GetAllAndSearch(string url)
        {
            
            var result = await _teamPost.GetOdataTeamPostAsync(url);
            var teamPost = JsonConvert.DeserializeObject<ReadTeamPostDTO>(result);

            // lấy userId
            var userId = teamPost.CreatedBy;


            return Content(result, "application/json");
        }
    }
}
