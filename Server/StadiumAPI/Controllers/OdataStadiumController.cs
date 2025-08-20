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
    [Route("odata/OdataStadium")]
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
        public IQueryable<Stadiums> Get()
        {
            var stadiums = _serviceStadium.GetAllOdataStadiums(); // IQueryable<Stadiums>
            return stadiums;
        }



    }
}
