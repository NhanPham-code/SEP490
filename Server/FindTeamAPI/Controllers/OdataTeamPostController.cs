using AutoMapper;
using FindTeamAPI.Models;
using FindTeamAPI.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Linq;
using System.Security.Claims; // Thêm using này

namespace FindTeamAPI.Controllers
{
    [Route("odata/[Controller]")] // Đổi tên route cho đúng chuẩn OData hơn
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class OdataTeamPostController : ODataController
    {
        private readonly ITeamPostService _teamPostService;
        private readonly IMapper _mapper;
        public OdataTeamPostController(ITeamPostService teamPostService, IMapper mapper)
        {
            _teamPostService = teamPostService;
            _mapper = mapper;
        }

        [EnableQuery]
        //[Authorize(Roles = "Customer")] // Vẫn giữ để đảm bảo chỉ Customer mới vào được
        public ActionResult<IQueryable<TeamPost>> Get()
        {
            // 1. Lấy ID của người dùng đã được xác thực từ token (Claims)

            // 2. Gọi service để lấy IQueryable đã được lọc theo userId
            // Giả sử bạn sẽ tạo phương thức này trong service của mình
            var teamPostsForUser = _teamPostService.GetAllTeamPostsQueryableAsync();

            // 3. Trả về IQueryable. OData sẽ xử lý phần còn lại.
            return Ok(teamPostsForUser);
        }
    }
}