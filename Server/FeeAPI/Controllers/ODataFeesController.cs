using FeeAPI.Model;
using FeeAPI.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace FeeAPI.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ODataFeesController : ODataController
    {
        private readonly IFeeService _feeService;

        public ODataFeesController(IFeeService feeService)
        {
            _feeService = feeService;
        }

        // /odata/ODataFees
        [EnableQuery]
        public IQueryable<Fee> Get()
        {
            return _feeService.QueryFees();
        }
    }
}
