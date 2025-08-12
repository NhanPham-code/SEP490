using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using StadiumAPI.DTOs;
using StadiumAPI.Models;
using StadiumAPI.Service.Interface;

namespace StadiumAPI.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)] // Ignore this controller in Swagger documentation
    public class OdataStadiumController : ODataController
    {
        private readonly IServiceStadium _serviceStadium;
        private readonly IMapper _mapper;
        public OdataStadiumController(IServiceStadium serviceStadium, IMapper mapper)
        {
            _serviceStadium = serviceStadium;
            _mapper = mapper;
        }
        
        public IQueryable<ReadStadiumDTO> Get(ODataQueryOptions<Stadiums> oDataQueryOptions)
        {
            // Use the service to get the OData queryable collection of stadiums
            IQueryable<Stadiums> stadiums = _serviceStadium.GetAllOdataStadiums();

            // 2. Áp dụng các tùy chọn truy vấn OData vào IQueryable<User>
            // Điều này sẽ thực hiện lọc, sắp xếp, phân trang ở cấp độ DB (nếu dùng EF Core)
            // queryOptions.ApplyTo trả về IQueryable (non-generic), cần Cast lại về IQueryable<User>
            IQueryable<Stadiums> results = (IQueryable<Stadiums>)oDataQueryOptions.ApplyTo(stadiums);

            // 3. Chiếu kết quả (hiện đang là IQueryable<User>) sang IQueryable<ReadUserDTO>
            // Đảm bảo bạn có cấu hình AutoMapper để ánh xạ từ User sang ReadUserDTO
            IQueryable<ReadStadiumDTO> projectedResults = results.ProjectTo<ReadStadiumDTO>(_mapper.ConfigurationProvider);
            return projectedResults;
        }
    }
}
