using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using UserAPI.DTOs;
using UserAPI.Model;
using UserAPI.Service.Interface;

namespace UserAPI.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ODataAdminUsersController : ODataController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ODataAdminUsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // /odata/ODataUsers
        public IQueryable<AdminUserProfileDTO> Get(ODataQueryOptions<User> queryOptions) // <--- Kiểu tham số là User, kiểu trả về là IQueryable<ReadUserDTO>
        {
            // 1. Lấy IQueryable<User> từ Service/Repository
            IQueryable<User> users = _userService.GetAllUsersForOData();

            // 2. Áp dụng các tùy chọn truy vấn OData vào IQueryable<User>
            // Điều này sẽ thực hiện lọc, sắp xếp, phân trang ở cấp độ DB (nếu dùng EF Core)
            // queryOptions.ApplyTo trả về IQueryable (non-generic), cần Cast lại về IQueryable<User>
            IQueryable<User> results = (IQueryable<User>)queryOptions.ApplyTo(users);

            // 3. Chiếu kết quả (hiện đang là IQueryable<User>) sang IQueryable<ReadUserDTO>
            // Đảm bảo bạn có cấu hình AutoMapper để ánh xạ từ User sang ReadUserDTO
            IQueryable<AdminUserProfileDTO> projectedResults = results.ProjectTo<AdminUserProfileDTO>(_mapper.ConfigurationProvider);

            // 4. Trả về kết quả đã được chiếu. OData sẽ định dạng nó.
            return projectedResults;
        }
    }
}
