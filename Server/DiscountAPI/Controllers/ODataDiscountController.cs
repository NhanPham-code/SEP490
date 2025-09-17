using DiscountAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DiscountAPI.Controllers
{

    public class ODataDiscountController : ODataController
    {
        private readonly IDiscountService _service;

        public ODataDiscountController(IDiscountService service)
        {
            _service = service;
        }

        // OData GET - hỗ trợ $filter, $select, $orderby, $top, $count ...
        [EnableQuery]
        public IActionResult Get()
        {
            var result = _service.GetAll();
            return Ok(result); // OData formatter sẽ tự thêm @odata.context, @odata.count
        }
    }
}
