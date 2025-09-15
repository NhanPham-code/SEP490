using AutoMapper;
using FindTeamAPI.Models;
using FindTeamAPI.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace FindTeamAPI.Controllers
{
    [Route("odata/OdataTeamPost")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)] // Ignore this controller in Swagger documentation
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
        [Authorize(Roles = "Customer")]
        public IQueryable<TeamPost> Get()
        {
            var TeamPost = _teamPostService.GetAllTeamPostsQueryableAsync(); // Assuming 0 is the teamId for all posts
            return TeamPost;
        }
    }
}
