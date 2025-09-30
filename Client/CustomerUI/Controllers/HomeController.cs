using CustomerUI.Models;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using Service.Interfaces;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CustomerUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStadiumService _stadiumService;
        private readonly ITeamPostService _teamPostService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;


        public HomeController(ILogger<HomeController> logger, IStadiumService stadiumService, ITeamPostService teamPostService, ITokenService tokenService, IUserService userService)
        {
            _logger = logger;

            _stadiumService = stadiumService;
            _teamPostService = teamPostService;
            _tokenService = tokenService;
            _userService = userService;
        }


        //kết nối signalR ở đây
        public async Task<HubConnection> HubConnection()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7072/notificationHub", options =>
                {
                    var token = _tokenService.GetAccessTokenFromCookie();
                    options.AccessTokenProvider = () => Task.FromResult(token);
                })
                .WithAutomaticReconnect()
                .Build();
            await connection.StartAsync();
            if (connection.State == HubConnectionState.Connected)
            {
                Console.WriteLine("Kết nối SignalR thành công!");
            }
            else
            {
                Console.WriteLine("Kết nối thất bại!");
            }

            return connection;
        }

        //đăng ký group
        public async Task<bool> RegisterGroup(HubConnection connection)
        {
            DateTime date = DateTime.UtcNow;
            var formatted = date.ToString("o");

            // lay userid tu session
            int myUserId = HttpContext.Session.GetInt32("UserId") ?? 0;
            // lay userid tu team postservice
            var userId = await _teamPostService.GetOdataTeamPostAsync($"&$filter=TeamMembers/any(tm: tm/UserId eq {myUserId}) and PlayDate gt {formatted}");

            List<string> groupNames = new List<string>();
            foreach (var item in userId.Value)
            {
                foreach (var member in item.TeamMembers)
                {
                    if (member.UserId == myUserId)
                    {
                        groupNames.Add(item.Id.ToString());
                    }
                }
            }
            Console.WriteLine("Group names to register: " + string.Join(", ", groupNames));

            bool registered = await connection.InvokeAsync<bool>("RegisterGroups", groupNames);
            return registered;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                await RegisterGroup(await HubConnection());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }

            return View();
        }


        public async Task<IActionResult> Stadiums(string searchTerm)
        {

           
            var stadium = await _stadiumService.SearchStadiumAsync(searchTerm);

            return Content(stadium, "application/json");
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Map()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
