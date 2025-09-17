using DTOs.FindTeamDTO;
using DTOs.StadiumDTO;
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
        private readonly IStadiumService _stadiumService;
        private readonly IBookingService _bookingService;
        private string token = string.Empty;
        public FindTeamController(ITeamPostService teamPost, ITeamMemberService teamMember,
            ITokenService tokenService, IUserService userService, IStadiumService stadiumService,
            IBookingService bookingService)
        {
            _teamPost = teamPost;
            _teamMember = teamMember;
            _tokenService = tokenService;
            _userService = userService;
            _stadiumService = stadiumService;
            _bookingService = bookingService;
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
        public IActionResult TeamPostManage()
        {
            token = _tokenService.GetAccessTokenFromCookie();
            return View();
        }


        public async Task<IActionResult> GetAllAndSearch(string url)
        {
            
            var result = await _teamPost.GetOdataTeamPostAsync(url);
            
            List<int> userId = result.Value.Select(u => u.CreatedBy).ToList();
            List<int> stadiumId = result.Value.Select(s => s.StadiumId).ToList();
            // get profile by id 
            var tokes = _tokenService.GetAccessTokenFromCookie();
            var profile = await _userService.GetUsersByIdsAsync(userId , tokes);
            var stadiums = await _stadiumService.GetAllStadiumByListId(stadiumId);

            FindTeamViewModel findTeamViewModel = new FindTeamViewModel
            {
                TeamPosts = result.Value,
            };

            foreach (var item in findTeamViewModel.TeamPosts)
            {
                var user = profile.FirstOrDefault(u => u.UserId.Equals(item.CreatedBy));
                if (user != null)
                {
                    findTeamViewModel.UserNames.Add(item.CreatedBy, user);
                }
            }


            return Json(findTeamViewModel);
        }


        public async Task<IActionResult> GetBookByUserId()
        {
            var queryString = "";
            var booking = await _bookingService.GetBookingAsync(_tokenService.GetAccessTokenFromCookie(), queryString);
            
            List<int> stadiumId = booking.Select(s => s.StadiumId).ToList();
            BookingAndStadiumViewModel bookingAndStadiumViewModel = new BookingAndStadiumViewModel();
            bookingAndStadiumViewModel.Bookings = booking;
          
            var s = await _stadiumService.GetAllStadiumByListId(stadiumId);
            foreach (var item in s.Value)
            {
                var bookingDetail = await _bookingService.GetBookingDetailAsync(_tokenService.GetAccessTokenFromCookie(), item.Id);
                Console.WriteLine(JsonConvert.SerializeObject(bookingDetail));
                bookingAndStadiumViewModel.Stadiums.Add(item.Id, item);
            }

            return Json(bookingAndStadiumViewModel);
        }

    }
}
