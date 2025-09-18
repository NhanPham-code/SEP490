using DTOs.FindTeamDTO;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace CustomerUI.Controllers
{
    public class TeamMemberController : Controller
    {

        private readonly ITeamMemberService _teamMember;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly ITeamPostService _teamPost;
        private string token;
        public TeamMemberController(ITeamMemberService teamMember, ITokenService tokenService, IUserService userService, ITeamPostService teamPost)
        {
            _teamMember = teamMember;
            _tokenService = tokenService;
            _userService = userService;
            _teamPost = teamPost;
        }

        public IActionResult TeamManage([FromQuery] int postId)
        {
            if (postId <= 0)
            {
                return RedirectToAction("TeamPostManage", "FindTeam");
            }
            ViewBag.PostId = postId;
            return View();
        }


        public async Task<IActionResult> GetTeamMemberDetail([FromQuery] int postId)
        {
            if (postId <= 0)
            {
                return Json(null);
            }
            MemberViewModel memberViewModel = new MemberViewModel();
            // get my id from session
            var myUserId = HttpContext.Session.GetInt32("UserId") ?? 0;

            token = _tokenService.GetAccessTokenFromCookie();
            memberViewModel.TeamMembers = (await _teamMember.GetAllTeamMemberByPostId(postId)).ToList();
            var userId = memberViewModel.TeamMembers.Select(tm => tm.UserId).ToList();
            var profile = await _userService.GetUsersByIdsAsync(userId, token);
            // add leaderId vào dictionary 
            

            var profileDict = profile.ToDictionary(p => p.UserId);
            foreach (var member in memberViewModel.TeamMembers)
            {
                if (profileDict.TryGetValue(member.UserId, out var userProfile))
                {
                    memberViewModel.Users.Add(member.UserId, userProfile);
                }
            }
            memberViewModel.LeaderId = memberViewModel.TeamMembers.FirstOrDefault(tm => tm.role == "Leader" && tm.UserId.Equals(myUserId))?.UserId ?? 0;
            if (memberViewModel.Users.Any() && memberViewModel.TeamMembers.Any())
            {
                return Json(memberViewModel);
            }

            return Json(null);
        }
    }
}
