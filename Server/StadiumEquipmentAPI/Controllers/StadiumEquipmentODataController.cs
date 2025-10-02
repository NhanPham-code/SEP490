using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using StadiumEquipmentAPI.Data;
using StadiumEquipmentAPI.Models;

namespace StadiumEquipmentAPI.Controllers
{
    // ⚡ Controller này KHÔNG xài Service/DTO, mà trả trực tiếp Entity cho OData
    public class StadiumEquipmentODataController : ODataController
    {
        private readonly StadiumEquipmentDbContext _context;

        public StadiumEquipmentODataController(StadiumEquipmentDbContext context)
        {
            _context = context;
        }

        // GET /odata/StadiumEquipmentOData
        [EnableQuery]
        public IQueryable<StadiumEquipments> Get()
        {
            return _context.StadiumEquipments;
        }

    }
}
