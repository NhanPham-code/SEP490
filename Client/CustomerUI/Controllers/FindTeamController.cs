using DTOs.FindTeamDTO;
using DTOs.NotificationDTO;
using DTOs.StadiumDTO;
using FindTeamAPI.DTOs;
using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Service.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CustomerUI.Controllers
{
    public class FindTeamController : Controller
    {

        private readonly ITeamPostService _teamPost;
        private readonly ITeamMemberService _teamMember;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IStadiumService _stadiumService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        private string token = string.Empty;
        public FindTeamController(ITeamPostService teamPost, ITeamMemberService teamMember,
            ITokenService tokenService, IUserService userService, IStadiumService stadiumService,
            IBookingService bookingService, INotificationService notificationService)
        {
            _teamPost = teamPost;
            _teamMember = teamMember;
            _tokenService = tokenService;
            _userService = userService;
            _stadiumService = stadiumService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        [BindProperty]
        public CreateTeamPostDTO CreateTeamPostDTO { get; set; }
        [BindProperty]
        public UpdateTeamPostDTO UpdateTeamPostDTO { get; set; }

        //kết nối với signalR
        private async Task<HubConnection> ConnectToSignalRAsync()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7072/notificationHub", options =>
                {
                    options.AccessTokenProvider = () => Task.FromResult(_tokenService.GetAccessTokenFromCookie());
                })
                .WithAutomaticReconnect()
                .Build();

            await connection.StartAsync();
            return connection;
        }

        private async Task SendNotificationToUserAsync(NotificationDTO notification)
        {
            HubConnection connection = await ConnectToSignalRAsync();
            await connection.InvokeAsync("SendNotificationToUser", notification);
        }

        private async Task SendNotificationToGroupUserAsync( string groupName, List<NotificationDTO> notificationDTOs)
        {
            HubConnection connection = await ConnectToSignalRAsync();
            await connection.InvokeAsync("SendNotificationToGroup", groupName, notificationDTOs);
        }

        private async Task<bool> RegisterGroupAsync(string groupName)
        {
            HubConnection connection = await ConnectToSignalRAsync();
            try
            {
                await connection.InvokeAsync("RegisterGroups", groupName);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering group: {ex.Message}");
                return false;
            }
        }

        public IActionResult FindTeam()
        {
            token = _tokenService.GetAccessTokenFromCookie();
            if (token != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Common");
            }
            
        }
        public IActionResult JoinedTeam()
        {
            token = _tokenService.GetAccessTokenFromCookie();
            if (token != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Common");
            }

        }
        public IActionResult TeamPostManage()
        {
            token = _tokenService.GetAccessTokenFromCookie();
            if (token != null)
            {
                
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Common");
            }
        }

        //get all post and search
        public async Task<IActionResult> GetAllAndSearch(string url)
        {
            var dateNow = DateTime.UtcNow;
            var formatted = dateNow.ToString("o");
            //2025-08-18 11:08:41.5130000
            var result = await _teamPost.GetOdataTeamPostAsync($"&$filter=PlayDate gt {formatted} {url}");
            if (!result.Value.Any())
            {
                return Json(new { Message = 404 });
            }
            // my user id
            int myUserId = HttpContext.Session.GetInt32("UserId") ?? 0;

            List<int> userId = result.Value.Select(u => u.CreatedBy).ToList();

            // get profile by id 
            var tokes = _tokenService.GetAccessTokenFromCookie();
            var profile = await _userService.GetUsersByIdsAsync(userId , tokes);
            // add vào view model để biết có phải người tạo bài đăng hay không mà hiện nút xóa nút tham gia

            FindTeamViewModel findTeamViewModel = new FindTeamViewModel
            {
                TeamPosts = result.Value,
                TotalCount = result.Count
            };

            foreach (var item in findTeamViewModel.TeamPosts)   
            {
                var user = profile.FirstOrDefault(u => u.UserId.Equals(item.CreatedBy));
                if (user != null && findTeamViewModel.UserNames.Keys.Contains(item.CreatedBy) != true) // theem user của bày đăng vào dictionary
                {
                    findTeamViewModel.UserNames.Add(item.CreatedBy, user);
                }   
                if (myUserId == item.CreatedBy && findTeamViewModel.Hidden.Keys.Contains(item.CreatedBy) != true) // nếu là người tạo bài đăng thì ẩn nút tham gia
                {
                    findTeamViewModel.Hidden.Add(item.Id, 1);
                }
                else if (item.TeamMembers.Any(t => t.UserId.Equals(myUserId))) // nếu đã tham gia bài đăng thì ẩn nút tham gia
                {
                    findTeamViewModel.Hidden.Add(item.Id, 2);
                }
            }


            return Json(findTeamViewModel);
        }

        // get booking by user id
        public async Task<IActionResult> GetBookByUserId()
        {
            var myUserId = HttpContext.Session.GetInt32("UserId") ?? 0;


            var dateNow = DateTime.UtcNow;
            var formatted = dateNow.ToString("o");
            //get booking by user id
            string url = $"?$expand=BookingDetails&$filter=UserId eq {myUserId} and BookingDetails/any(m: m/StartTime ge {formatted})";
            var booking = await _bookingService.GetBookingAsync(_tokenService.GetAccessTokenFromCookie(), url);
     
            if (booking == null || !booking.Any())
            {
                return Json(new { Message = 404 });
            }
            var stadiumId = booking.Select(s => s.StadiumId).Distinct().ToList();
            // get team post by user id and role is leader

            var post = await _teamPost.GetOdataTeamPostAsync($"&$filter=CreatedBy eq {myUserId} and TeamMembers/any(m: m/Role eq 'Leader') ");

            // get stadium by list id
            var s = await _stadiumService.GetAllStadiumByListId(stadiumId);

            BookingAndStadiumViewModel bookingAndStadiumViewModel = new BookingAndStadiumViewModel();
            // lọc những booking đã tạo team post rồi thì không hiện nữa
            var ints = post.Value.Select(p => p.BookingId).ToHashSet(); 
            bookingAndStadiumViewModel.Bookings = booking.Where(b => !ints.Contains(b.Id)).ToList();

            
            //thêm stadium vào dictionary theo key là các id của stadium trong booking để dễ truy xuất
            foreach (var item in s.Value)
            {
                
                bookingAndStadiumViewModel.Stadiums.Add(item.Id, item);

            }

            return Json(bookingAndStadiumViewModel);
        }
        //create new post
        public async Task<IActionResult> CreateNewPost()
        {
            CreateTeamPostDTO.CreatedBy = HttpContext.Session.GetInt32("UserId") ?? 0;
            CreateTeamPostDTO.CreatedAt = DateTime.UtcNow;
            CreateTeamPostDTO.UpdatedAt = DateTime.UtcNow;
            var result = await _teamPost.CreateTeamPost(CreateTeamPostDTO);
            if (result == null)
            {
                return Json(new { Message = 500, value = "Create team post failed" });
            }

            //tao leader cho team post vua tao
            var teamMember = new CreateTeamMemberDTO
            {
                TeamPostId = result.Id,
                UserId = CreateTeamPostDTO.CreatedBy,
                JoinedAt = DateTime.UtcNow,
                role = "Leader"
            };
            var res = await _teamMember.AddTeamMember(teamMember);
            if (res == null)
            {
                await _teamPost.DeleteTeamPost(result.Id);
                return Json(new { Message = 500, value = "Create team member failed" });
            }
            // signalR đăng ký group theo id bài đăng để gửi notification cho những người trong nhóm
            _ = await _notificationService.SendNotificationToAll(new NotificationDTO
            {
                Title = "Vừa có một nhóm được tạo",
                Message = "A new team post has been created. Check it out!",
                Type = "Recruitment.NewPost",
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            });

            return Json(new { Message = 200, value = result });
        }

        // get my team post
        public async Task<IActionResult> GetMyTeamPost()
        {
            int myUserId = HttpContext.Session.GetInt32("UserId") ?? 0;

            var result = await _teamPost.GetOdataTeamPostAsync(
                $"&$filter=CreatedBy eq {myUserId} and TeamMembers/any(m: m/Role eq 'Leader')"
            );
            if (result.Value.Any() == false)
            {
                return Json(new { Message = 404 });
            }
            List<int> userId = result.Value.Select(u => u.CreatedBy).ToList();

            // get profile by id 
            var tokes = _tokenService.GetAccessTokenFromCookie();
            var profile = await _userService.GetUsersByIdsAsync(userId, tokes);
            // add vào view model để biết có phải người tạo bài đăng hay không mà hiện nút xóa nút tham gia

            FindTeamViewModel findTeamViewModel = new FindTeamViewModel
            {
                TeamPosts = result.Value,
                TotalCount = result.Count
            };

            // Chuyển danh sách profile thành Dictionary để tra cứu nhanh hơn.
            // Key là UserId, Value là đối tượng user.
            var profileDict = profile.ToDictionary(u => u.UserId);

            foreach (var item in findTeamViewModel.TeamPosts)
            {
                // Sử dụng TryGetValue để tra cứu user một cách hiệu quả và an toàn.
                if (!findTeamViewModel.UserNames.ContainsKey(item.CreatedBy) && profileDict.TryGetValue(item.CreatedBy, out var user))
                {
                    findTeamViewModel.UserNames.Add(item.CreatedBy, user);
                }
               
           
                findTeamViewModel.TeamPosts.ForEach(tp =>
                {
                    var playDate = DateTimeOffset.Parse(tp.PlayDate.ToString());
                    if (playDate < DateTime.UtcNow && !findTeamViewModel.Hidden.ContainsKey(tp.Id))
                    {
                        findTeamViewModel.Hidden.Add(tp.Id, 1); // 3 = đã qua, không hiện nút xóa
                    }
                });


            }


            return Json(findTeamViewModel);
        }

        // joined team post
        public async Task<IActionResult> JoinedTeamPost(string url)
        {
            var dateNow = DateTime.UtcNow;
            var formatted = dateNow.ToString("o");
            int myUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            //2025-08-18 11:08:41.5130000
            var odata = $"&$filter=PlayDate gt {formatted} and TeamMembers/any(tm: tm/UserId eq {myUserId}) {url}";

            var result = await _teamPost.GetOdataTeamPostAsync(odata);
            if (!result.Value.Any())
            {
                return Json(new { Message = 404 });
            }
            // my user id
           

            List<int> userId = result.Value.Select(u => u.CreatedBy).ToList();

            // get profile by id 
            var tokes = _tokenService.GetAccessTokenFromCookie();
            var profile = await _userService.GetUsersByIdsAsync(userId, tokes);
            // add vào view model để biết có phải người tạo bài đăng hay không mà hiện nút xóa nút tham gia

            FindTeamViewModel findTeamViewModel = new FindTeamViewModel
            {
                TeamPosts = result.Value,
                TotalCount = result.Count
            };

            foreach (var item in findTeamViewModel.TeamPosts)
            {
                var user = profile.FirstOrDefault(u => u.UserId.Equals(item.CreatedBy));
                if (user != null && findTeamViewModel.UserNames.Keys.Contains(item.CreatedBy) != true) // theem user của bày đăng vào dictionary
                {
                    findTeamViewModel.UserNames.Add(item.CreatedBy, user);
                }
                if (myUserId == item.CreatedBy && findTeamViewModel.Hidden.Keys.Contains(item.CreatedBy) != true) // nếu là người tạo bài đăng thì ẩn nút tham gia
                {
                    findTeamViewModel.Hidden.Add(item.Id, 1);
                }
                else if (item.TeamMembers.Any(t => t.UserId.Equals(myUserId))) // nếu đã tham gia bài đăng thì ẩn nút tham gia
                {
                    findTeamViewModel.Hidden.Add(item.Id, 2);
                }
            }

          

            return Json(findTeamViewModel);
        }


        // join team post
        public async Task<IActionResult> JoinTeamPost(int postId)
        {
            int myUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var teamMember = new CreateTeamMemberDTO
            {
                TeamPostId = postId,
                UserId = myUserId,
                JoinedAt = DateTime.UtcNow,
                role = "Waiting"
            };
            var res = await _teamMember.AddTeamMember(teamMember);
            if (res == null)
            {
                return Json(new { Message = 500, value = "Join team post failed" });
            }
            var post = await _teamPost.GetOdataTeamPostAsync($"&$filter=Id eq {postId}");
            // gửi notification cho người tạo bài đăng biết có người tham gia
            SendNotificationToUserAsync( new NotificationDTO
            {
                UserId = post.Value.Select(p => p.CreatedBy).FirstOrDefault(),
                Type = "Recruitment.JoinRequest",
                Title = "<h3 class=\"text-green-500\">Yêu cầu tham gia nhóm</h3>",
                Message = "<div><span>Đã có một thành viên tham gia vào nhóm của bạn: </span><a class=\"text-blue-400\" style=\"text-decoration: underline;\" href=\"/TeamMember/TeamManage?postId=" + postId + "\">Xem chi tiết</a></div>",
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            }).GetAwaiter().GetResult();
            return Json(new { Message = 200, value = res });
        }

        public async Task<IActionResult> GetPostById(int postId)
        {
            //get my user id
            int myUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            TeamPostEditViewModel teamPostDetailViewModel = new TeamPostEditViewModel();
            var result = await _teamPost.GetOdataTeamPostAsync($"&$filter=Id eq {postId} and CreatedBy eq {myUserId}");
            teamPostDetailViewModel.TeamPost = result.Value.FirstOrDefault();
            teamPostDetailViewModel.User = await _userService.GetMyProfileAsync(_tokenService.GetAccessTokenFromCookie());
        

            if (teamPostDetailViewModel == null)
            {
                return Json(null);
            }
            return Json(teamPostDetailViewModel);
        }

        public async Task<IActionResult> UpdateTeamPost()
        {
            if (UpdateTeamPostDTO == null)
            {
                return Json(new { Message = 500, value = "Update team post failed" });
            }
            // get my user id
            var oldPost = await _teamPost.GetOdataTeamPostAsync($"&$filter=Id eq {UpdateTeamPostDTO.Id}");
            if (oldPost == null || !oldPost.Value.Any())
            {
                return Json(new { Message = 404, value = "Team post not found" });
            }
            var old = oldPost.Value.FirstOrDefault();
            UpdateTeamPostDTO.UpdatedAt = DateTime.UtcNow;
            UpdateTeamPostDTO.JoinedPlayers = old.JoinedPlayers;
            var update = await _teamPost.UpdateTeamPost(UpdateTeamPostDTO);
            return Json(update);
        }

        // delete team post
        public async Task<IActionResult> DeleteTeamPost(int postId)
        {
            var members = await _teamMember.GetAllTeamMemberByPostId(postId);
            List<NotificationDTO> notificationDTOs = new List<NotificationDTO>();
            // gửi notification cho tất cả thành viên trong bài đăng biết bài đăng đã bị xóa
            foreach (var member in members)
            {
                if (member.UserId != null && member.UserId != 0)
                {

                    notificationDTOs.Add(new NotificationDTO
                    {
                        UserId = (Int32)member.UserId,
                        Type = "Recruitment.Accepted",
                        Title = "<h3 class=\"text-red-600\">Bài đăng đã bị xóa</h3>",
                        Message = "<div><span>Bài đăng mà bạn tham gia đã bị xóa bởi người tạo. </span><a class=\"text-blue-400\" style=\"text-decoration: underline;\" href=\"/FindTeam/FindTeam\">Tìm bài đăng khác</a></div>",
                        IsRead = false,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }
            await SendNotificationToGroupUserAsync(postId.ToString(), notificationDTOs);
            if (postId <= 0)
            {
                return Json(new { Message = 500, value = "Delete team post failed" });
            }

            // xóa bài đăng
            var result = await _teamPost.DeleteTeamPost(postId);
            if (result == false)
            {
                return Json(new { Message = false, value = "Delete team post failed" });
            }
            // xóa thành viên
            if (members != null && members.Any())
            {
                foreach (var member in members)
                {
                    await _teamMember.DeleteTeamMember(member.Id, postId);
                }
            }
            return Json(new { Message = true, value = "Delete team post successfully" });
        }

        // chuyển đổi từ datetime sang timespan
        public TimeSpan ConvertToTimeSpan(DateTime dateTime)
        {
            return dateTime.TimeOfDay;
        }

    }
}
