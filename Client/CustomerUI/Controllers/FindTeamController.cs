using DTOs.BookingDTO; 
using DTOs.FindTeamDTO;
using DTOs.NotificationDTO;
using FindTeamAPI.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Service.Interfaces;
using System.Text.Json;

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
        private readonly IEmailService _emailService;

        private string token = string.Empty;

        public FindTeamController(ITeamPostService teamPost, ITeamMemberService teamMember,
            ITokenService tokenService, IUserService userService, IStadiumService stadiumService,
            IBookingService bookingService, INotificationService notificationService, IEmailService emailService)
        {
            _teamPost = teamPost;
            _teamMember = teamMember;
            _tokenService = tokenService;
            _userService = userService;
            _stadiumService = stadiumService;
            _bookingService = bookingService;
            _notificationService = notificationService;
            _emailService = emailService;
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

        private async Task SendNotificationToUserAsync(CreateNotificationDto notification)
        {
            HubConnection connection = await ConnectToSignalRAsync();
            _notificationService.SendNotificationToUserAsync(notification).GetAwaiter().GetResult();
           
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

        public async Task<IActionResult> FindTeam()
        {
            token = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Common");
            }

            var profile = await _userService.GetMyProfileAsync(token);

            ViewBag.UserId = profile?.UserId;
            ViewBag.UserName = profile?.FullName ?? "User";
            ViewBag.Profile = profile;

            return View();
        }

        public async Task<IActionResult> JoinedTeam()
        {
            token = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Common");
            }

            var profile = await _userService.GetMyProfileAsync(token);

            ViewBag.UserId = profile?.UserId;
            ViewBag.UserName = profile?.FullName ?? "User";
            ViewBag.Profile = profile;

            return View();
        }

        public async Task<IActionResult> TeamPostManage()
        {
            token = _tokenService.GetAccessTokenFromCookie();
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Common");
            }

            var profile = await _userService.GetMyProfileAsync(token);

            ViewBag.UserId = profile?.UserId;
            ViewBag.UserName = profile?.FullName ?? "User";
            ViewBag.Profile = profile;

            return View();
        }


        //get all post and search
        public async Task<IActionResult> GetAllAndSearch(string url)
        {
            var dateNow = DateTime.UtcNow;
            var formatted = dateNow.ToString("o");
            //2025-08-18 11:08:41.5130000
            var result = await _teamPost.GetOdataTeamPostAsync($"&$orderby=PlayDate asc&$filter=PlayDate gt {formatted} {url}");
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
            string url = $"?$expand=BookingDetails&$filter=UserId eq {myUserId} and Status eq 'accepted' and BookingDetails/any(m: m/StartTime gt {formatted}) ";
            var booking = (await _bookingService.GetBookingAsync(_tokenService.GetAccessTokenFromCookie(), url)).Data;
     
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
        
        // Trong file: FindTeamController.cs

        [HttpGet]
        public async Task<IActionResult> GetJoinedBookingIds(DateTime startDate, DateTime endDate)
        {
            var myUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var token = _tokenService.GetAccessTokenFromCookie();

            string startIso = startDate.ToString("yyyy-MM-ddT00:00:00Z");
            string endIso = endDate.ToString("yyyy-MM-ddT23:59:59Z");

            // 1. Lấy TeamPost (để lấy được cả BookingId lẫn PostId)
            var query = $"&$filter=TeamMembers/any(m: m/UserId eq {myUserId} and m/Role eq 'Member') and PlayDate ge {startIso} and PlayDate le {endIso}&$select=BookingId,Id"; 
            // Lưu ý: Select thêm Id (chính là PostId)

            var teamPostResult = await _teamPost.GetOdataTeamPostAsync(query);

            if (teamPostResult?.Value == null || !teamPostResult.Value.Any())
            {
                return Json(new List<object>());
            }

            var teamPosts = teamPostResult.Value; // List các bài đăng
            var bookingIds = teamPosts.Select(p => p.BookingId).Distinct().ToList();

            // 2. Gọi Booking Service lấy chi tiết booking
            var idFilters = bookingIds.Select(id => $"Id eq {id}");
            var odataFilter = string.Join(" or ", idFilters);
            var bookingQuery = $"?$filter={odataFilter}&$expand=BookingDetails";
    
            var bookingsResult = await _bookingService.GetBookingAsync(token, bookingQuery);
            var bookings = bookingsResult.Data ?? new List<BookingReadDto>();

            // 3. KẾT HỢP: Booking + PostId
            // Trả về một Anonymous Object chứa cả 2 thông tin
            var result = bookings.Select(b => {
                // Tìm bài đăng tương ứng với booking này
                var post = teamPosts.FirstOrDefault(p => p.BookingId == b.Id);
                return new 
                {
                    BookingData = b,     // Toàn bộ thông tin booking
                    PostId = post?.Id    // Id bài đăng để điều hướng
                };
            }).ToList();

            return Json(result);
        }
        
        //create new post
        public async Task<IActionResult> CreateNewPost()
        {
            CreateTeamPostDTO.CreatedBy = HttpContext.Session.GetInt32("UserId") ?? 0;

            DateTime combinedDateTime = CreateTeamPostDTO.PlayDate.Date + CreateTeamPostDTO.TimePlay;

            // 2. Gán trực tiếp đối tượng DateTime đã gộp lại cho PlayDate.
            CreateTeamPostDTO.PlayDate = combinedDateTime;

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
            _ = await _notificationService.SendNotificationToAll(new CreateNotificationDto
            {
                Title = "Vừa có một nhóm được tạo",
                Message = "A new team post has been created. Check it out!",
                Type = "Recruitment.NewPost",
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
            int createdBy = post.Value.Select(p => p.CreatedBy).FirstOrDefault();
            Console.WriteLine("CreatedBy: " + createdBy);
            // gửi notification cho người tạo bài đăng biết có người tham gia
            var json = JsonSerializer.Serialize(new
            {
                title = "TeamDetail",
                content = $"/TeamMember/TeamManage?postId={postId}"
            });
            SendNotificationToUserAsync( new CreateNotificationDto
            {
                UserId = createdBy,
                Type = "Recruitment.JoinRequest",
                Title = "Yêu cầu tham gia nhóm",
                Message = "Đã có một thành viên tham gia vào nhóm của bạn.",
                Parameters = json
            }).GetAwaiter().GetResult();
            var user = _userService.GetOtherUserByIdAsync(createdBy);
            _ = await _emailService.SendEmailAsync(user.Result.Email, "Yêu cầu tham gia nhóm", $"Đã có một thành viên tham gia vào nhóm {post.Value.Select(p => p.Title).FirstOrDefault()} của bạn.");
            //_ = await _notificationService.SendNotificationToAll(new CreateNotificationDto
            //{
            //    Title = "Một người vừa tham gia vào nhóm",
            //    Message = "Someone just joined a team. Check it out!",
            //    Type = "Recruitment.NewMember",
            //});
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
            List<CreateNotificationDto> notificationDTOs = new List<CreateNotificationDto>();
            var user = _userService.GetUsersByIdsAsync(members.Where(m => !m.role.Equals("Leader")).Select(m => m.UserId).ToList(), _tokenService.GetAccessTokenFromCookie());
            // gửi notification cho tất cả thành viên trong bài đăng biết bài đăng đã bị xóa
            foreach (var member in members)
            {
                if (member.UserId != null && member.UserId != 0)
                {
                    var json = JsonSerializer.Serialize(new
                    {
                        title = "FindTeam",
                        content = "/FindTeam/FindTeam"
                    });

                    notificationDTOs.Add(new CreateNotificationDto
                    {
                        UserId = (Int32)member.UserId,
                        Type = "Recruitment.Delete",
                        Title = "Bài đăng đã bị xóa",
                        Message = "Bài đăng mà bạn tham gia đã bị xóa bởi người tạo. Tìm bài đăng khác",
                        Parameters = json
                    });
                    
                    _ = await _emailService.SendEmailAsync(user.Result.Where(u => u.UserId.Equals(member.UserId)).Select(m => m.Email).FirstOrDefault(), "Bài đăng đã bị xóa", $"Bài đăng mà bạn tham gia đã bị xóa bởi người tạo. Tìm bài đăng khác");
                }
            }
            await _notificationService.SendNotificationToGroupUserAsync(postId.ToString(), notificationDTOs);
            if (postId <= 0)
            {
                return Json(new { Message = 500, value = "Delete team post failed" });
            }

            // xóa bài đăng
            var result = await _teamPost.DeleteTeamPost(postId);
            if (result == false)
            {
                return Json(new { Message = 400, value = "Delete team post failed" });
            }
            // xóa thành viên
            if (members != null && members.Any())
            {
                foreach (var member in members)
                {
                    await _teamMember.DeleteTeamMember(member.Id, postId);
                }
            }
            return Json(new { Message = 200, value = "Delete team post successfully" });
        }

        // chuyển đổi từ datetime sang timespan
        public TimeSpan ConvertToTimeSpan(DateTime dateTime)
        {
            return dateTime.TimeOfDay;
        }

    }
}
