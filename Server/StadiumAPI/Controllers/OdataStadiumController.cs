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
        [EnableQuery]
        public IQueryable<ReadStadiumDTO> Get(ODataQueryOptions<Stadiums> oDataQueryOptions)
        {
            // Use the service to get the OData queryable collection of stadiums
            IQueryable<Stadiums> stadiums = _serviceStadium.GetAllOdataStadiums();
            // Apply OData query options to the IQueryable collection
            IQueryable<Stadiums> results = (IQueryable<Stadiums>)oDataQueryOptions.ApplyTo(stadiums);
            // Project the results to ReadStadiumDTO using AutoMapper
            IQueryable<ReadStadiumDTO> projectedResults = results.ProjectTo<ReadStadiumDTO>(_mapper.ConfigurationProvider);
            return projectedResults;
        }
    }
}
