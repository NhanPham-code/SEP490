using DTOs.FindTeamDTO;
using DTOs.NotificationDTO;
using FindTeamAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Service.Interfaces;
using Service.Services;
using System.Text.Json;

namespace CustomerUI.Controllers
{
    public class TeamMemberController : Controller
    {

        private readonly ITeamMemberService _teamMember;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly ITeamPostService _teamPost;
        private readonly INotificationService _notificationService;
        private string token;
        public TeamMemberController(ITeamMemberService teamMember, ITokenService tokenService, IUserService userService, ITeamPostService teamPost, INotificationService notificationService)
        {
            _teamMember = teamMember;
            _tokenService = tokenService;
            _userService = userService;
            _teamPost = teamPost;
            _notificationService = notificationService;
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

            return Json(new { Message = 500, value = "" });
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
            // gửi thông báo cho thành viên được chấp nhận hoặc từ chối hoặc xóa khỏi đội
            

            // chấp nhận thành viên
            if (status == "Member")
            {
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
                if (update != null)
                {
                    // gửi thông báo cho thành viên được chấp nhận
       
                        _ = await _notificationService.SendNotificationToUserAsync(
                            new CreateNotificationDto
                            {
                                UserId = update.UserId,
                                Type = "Recruitment.Accepted",
                                Title = "<div class=\"text-green-500\">Yêu cầu tham gia nhóm của bạn đã được chấp nhận</div>",
                                Message = $"<div><span>Bạn đã được chấp nhận vào nhóm <span class=\"group-name\">{updateTeamPostDTO.Title}</span></span><a class=\"text-blue-400\" style=\"text-decoration: underline;\" href=\"/TeamMember/TeamManage?postId={postId}\">Xem chi tiết</a></div>",
                            });
                    _ = await _notificationService.SendNotificationToAll(new CreateNotificationDto
                    {
                        UserId = 0,
                        Type = "Test",
                        Title = "Test Notification",
                        Message = "This is a test notification sent to all users.",
                        Parameters = JsonSerializer.Serialize(post.Value),
                    });

                }
                // cập nhật số thành viên trên bài đăng
                var postMember = await _teamPost.UpdateTeamPost(updateTeamPostDTO);
                // nếu số thành viên đã đủ thì xóa các thành viên đang chờ
                if (postMember.JoinedPlayers == postMember.NeededPlayers)
                {
                    var allMember = await _teamMember.GetAllTeamMemberByPostId(postId);
                    foreach (var member in allMember)
                    {
                        if (member.role == "Waiting")
                        {
                            _ = await _notificationService.SendNotificationToUserAsync(
                                new CreateNotificationDto
                                {
                                    UserId = member.UserId,
                                    Type = "Recruitment.Full",
                                    Title = "Nhóm đã đủ thành viên",
                                    Message = $"<div><span>Nhóm <span class=\"group-name\">{updateTeamPostDTO.Title}</span> đã đủ thành viên</span><a class=\"text-blue-500\" style=\"text-decoration: underline;\" herf=\"/FindTeam/FindTeam\">Tìm nhóm khác</a></div>",
                                });
                            var deleteMember = await _teamMember.DeleteTeamMember(member.Id, postId);
                        }
                    }

                }

                if (update != null)
                {
                    return Json(new { Message = 200, value = "Cập nhật thành viên thành công!" });
                }
                return Json(new { Message = 500, value = "" });
            }
            else
            {
               
                // xóa thành viên khỏi đội
             
                int daletedMemberId = 0;
                string mesage = string.Empty;
                string messageTitle = string.Empty;
                string notifiMessage = string.Empty;
                int userId = 0;
                var post = await _teamPost.GetOdataTeamPostAsync($"&$filter=TeamMembers/any(tm: tm/Id eq {memberId})");
                // nếu là từ chối thì không trừ số thành viên
                    if (status == "Cancel")
                    {
                    notifiMessage = $"Bạn đã không được chủ nhóm <span class=\"group-name\">{post.Value.Select(p => p.Title).FirstOrDefault()}</span> chấp nhận";
                        mesage = "Từ chối thành viên thành công!";
                        messageTitle = "<div class=\"text-red-500\">Yêu cầu tham gia nhóm của bạn đã bị từ chối</div>";
                        userId = post.Value.SelectMany(p => p.TeamMembers).FirstOrDefault(tm => tm.Id == memberId).UserId;
                    }
                    // nếu là xóa hoặc rời đội thì trừ số thành viên
                    else if (status == "Delete")
                    {
                        daletedMemberId = 1;
                    notifiMessage = $"Bạn đã bị xóa khỏi nhóm <span class=\"group-name\">{post.Value.Select(p => p.Title).FirstOrDefault()}</span>";
                        mesage = "Đã xóa thành viên thành công!";
                        messageTitle = "<div class=\"text-red-500\">Bạn đã bị xóa khỏi nhóm</div>";
                        userId = post.Value.SelectMany(p => p.TeamMembers).FirstOrDefault(tm => tm.Id == memberId).UserId;
                    }
                    else if (status == "Leave")
                    {
                        if (role == "Member")
                        {
                            daletedMemberId = 1;
                        notifiMessage = $"Một thành viên đã rời khỏi nhóm <span class=\"group-name\">{post.Value.Select(p => p.Title).FirstOrDefault()}</span> của bạn";
                        messageTitle = "<div class=\"text-red-500\">Thành viên đã rời nhóm của bạn</div>";
                            userId = post.Value.Select(p => p.CreatedBy).FirstOrDefault();
                        }
                        mesage = "Rời đội thành công!";
                    }
                // gửi thông báo cho thành viên bị xóa hoặc từ chối hoặc rời đội
                
                
                _ = await _notificationService.SendNotificationToUserAsync(
                        new CreateNotificationDto
                        {
                            UserId = userId,
                            Type = "Recruitment.Removed",
                            Title = messageTitle,
                            Message = $"<div><span>{notifiMessage}</span><a class=\"text-blue-500\" style=\"text-decoration: underline;\" href=\"/FindTeam/FindTeam\">Tìm nhóm khác</a></div>",
                        });
                var result = await _teamMember.DeleteTeamMember(memberId, postId);

     
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
            var user = await _userService.SearchUsersByPhoneAsync(phoneNumber, token);
            if (user.Any())
            {
                //var allUser = await _userService.GetAllUsersAsync(token);
                //// lọc người chơi theo vị trí và loại hình thể thao
                //var filteredUsers = allUser.Where(u => u.Location.Contains(location, StringComparison.OrdinalIgnoreCase) && u.SportTypes.Contains(sportType, StringComparison.OrdinalIgnoreCase)).ToList();
                return Json(user);
            }
            return Json(new { Message = 404 });
        }
    }
}
