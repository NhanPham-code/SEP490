using DTOs.FindTeamDTO;
using FindTeamAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
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
            ViewBag.oldUrl = HttpContext.Request.Headers["Referer"].ToString();
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
            int myUserId = HttpContext.Session.GetInt32("UserId") ?? 0;

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
            // nếu là leader thì mới trả về leaderId
            memberViewModel.LeaderId = memberViewModel.TeamMembers.FirstOrDefault(tm => tm.role == "Leader" && tm.UserId == myUserId)?.UserId ?? 0;
            memberViewModel.TeamMembers.RemoveAt(0); // remove leader ra khỏi list để hiển thị
            if (memberViewModel.Users.Any() && memberViewModel.TeamMembers.Any())
            {
                return Json(memberViewModel);
            }

            return Json (new { Message = 500, value = "" });
        }

        // get team post detail by postId
        public async Task<IActionResult> GetTeamPostDetail([FromQuery] int postId)
        {
            if (postId <= 0)
            {
                return Json(null);
            }
            token = _tokenService.GetAccessTokenFromCookie();
            int myUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            TeamPostDetailViewModel teamPostDetailViewModel = new TeamPostDetailViewModel();
            var teamPost = await _teamPost.GetOdataTeamPostAsync($"&$filter=Id eq {postId}");
            teamPostDetailViewModel.TeamPost = teamPost.Value.FirstOrDefault();
            // get user profile by userId
            teamPostDetailViewModel.User = await _userService.GetOtherUserByIdAsync(teamPostDetailViewModel.TeamPost.CreatedBy);
            // tìm xem bạn có phải viên mới không
            var btn = teamPostDetailViewModel.TeamPost.TeamMembers.FirstOrDefault(n => n.UserId.Equals(myUserId));
            if (btn == null)
            {
                teamPostDetailViewModel.newMember = 1;
            }
            if (teamPostDetailViewModel.TeamPost.CreatedBy == myUserId)
            {
                teamPostDetailViewModel.isLeader = 1;
            }
            if (teamPostDetailViewModel != null && teamPost.Value.Any())
            {
                return Json(teamPostDetailViewModel);
            }
            return Json(null);
        }

        // chấp nhận từ chối hoặc xóa thành viên khỏi đội
        public async Task<IActionResult> ChangeStatusMember([FromQuery] int memberId, [FromQuery] int postId, [FromQuery] string status, [FromQuery] string role)
        {
            if (memberId <= 0 || postId <= 0)
            {
                return Json(new { Message = 500, value = "" });
            }
            token = _tokenService.GetAccessTokenFromCookie();
            if (status == "Member") {
                var updateMember = new UpdateTeamMemberDTO
                {
                    Id = memberId,
                    role = "Member"
                };
                var post = await _teamPost.GetOdataTeamPostAsync($"&$filter=Id eq {postId}");
                UpdateTeamPostDTO updateTeamPostDTO = new UpdateTeamPostDTO
                {
                    Id = postId,
                    Title = post.Value.FirstOrDefault().Title,
                    JoinedPlayers = post.Value.FirstOrDefault().JoinedPlayers + 1,
                    NeededPlayers = post.Value.FirstOrDefault().NeededPlayers,
                    PricePerPerson = post.Value.FirstOrDefault().PricePerPerson,
                    Description = post.Value.FirstOrDefault().Description,
                    UpdatedAt = DateTime.UtcNow
                };
                // cập nhật thành viên 
                var update = await _teamMember.UpdateTeamMember(updateMember);
                // cập nhật số thành viên trên bài đăng
                var postMember = await _teamPost.UpdateTeamPost(updateTeamPostDTO);
                if (postMember.JoinedPlayers == postMember.NeededPlayers)
                {
                    var allMember = await _teamMember.GetAllTeamMemberByPostId(postId);
                    foreach (var member in allMember)
                    {
                        if (member.role == "Waiting")
                        {
                          var deleteMember = await _teamMember.DeleteTeamMember(member.Id, postId);
                        }
                    }
                }
                
                if (update != null)
                {
                    return Json(new { Message = 200, value = "Cập nhật thành viên thành công!" });
                }
                return Json(new { Message = 500, value = "" });
            }else
            {
                var result = await _teamMember.DeleteTeamMember(memberId, postId);
                int daletedMemberId = 0;
                string mesage = string.Empty;
                if (result)
                {
                   
                    if (status == "Cancel")
                    {
                        mesage = "Từ chối thành viên thành công!";
                    }
                    else if (status == "Delete")
                    {
                        daletedMemberId = 1;
                        mesage = "Đã xóa thành viên thành công!";
                    }else if (status == "Leave"){
                        if (role == "Member")
                        {
                            daletedMemberId = 1;

                        }
                        mesage = "Rời đội thành công!";
                    }
                     
                }
                var post = await _teamPost.GetOdataTeamPostAsync($"&$filter=Id eq {postId}");
                UpdateTeamPostDTO updateTeamPostDTO = new UpdateTeamPostDTO
                {
                    Id = postId,
                    Title = post.Value.FirstOrDefault().Title,
                    JoinedPlayers = post.Value.FirstOrDefault().JoinedPlayers - daletedMemberId,
                    NeededPlayers = post.Value.FirstOrDefault().NeededPlayers,
                    PricePerPerson = post.Value.FirstOrDefault().PricePerPerson,
                    Description = post.Value.FirstOrDefault().Description,
                    UpdatedAt = DateTime.UtcNow
                };
                var postMember = await _teamPost.UpdateTeamPost(updateTeamPostDTO);
                return Json(new { Message = 200, value = mesage });
            }
        }

        // tìm người chơi khác để mời tham gia 
        public async Task<IActionResult> FindOtherPlayer([FromQuery] string phoneNumber)
        {
            if (phoneNumber.Length <= 0)
            {
                return Json(null);
            }
            token = _tokenService.GetAccessTokenFromCookie();
            var teamPost = await _userService.GetMyProfileAsync(token);
            if (teamPost != null)
            {
                //var allUser = await _userService.GetAllUsersAsync(token);
                //// lọc người chơi theo vị trí và loại hình thể thao
                //var filteredUsers = allUser.Where(u => u.Location.Contains(location, StringComparison.OrdinalIgnoreCase) && u.SportTypes.Contains(sportType, StringComparison.OrdinalIgnoreCase)).ToList();
                //return Json(filteredUsers);
            }
            return Json(teamPost);
        }
    }
}
