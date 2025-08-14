using AutoMapper;
using BookingAPI.Models;
using BookingAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BookingAPI.Controllers
{
    [Route("odata/Bookings")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BookingsControllerOData : ODataController
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingsControllerOData(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        // OData get all bookings queryable
        [EnableQuery]
        public IQueryable<Booking> GetBookings()
        {
            return _bookingService.GetAllBookingsAsQueryable();
        }
    }
}
    