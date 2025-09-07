using AutoMapper;
using BookingAPI.Models;
using BookingAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BookingAPI.Controllers
{
    public class BookingsController : ODataController // 🔹 Bỏ [Route], để OData tự map
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        // GET /odata/Bookings
        [EnableQuery]
        public IQueryable<Booking> Get()
        {
            return _bookingService.GetAllBookingsAsQueryable();
        }

        // GET /odata/Bookings(1)
        [EnableQuery]
        [Authorize(Roles = "Customer,StadiumManager")]
        public SingleResult<Booking> Get([FromODataUri] int key)
        {
            var result = _bookingService.GetAllBookingsAsQueryable()
                                        .Where(b => b.Id == key);
            return SingleResult.Create(result);
        }
    }
}