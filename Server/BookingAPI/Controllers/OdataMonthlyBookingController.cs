using AutoMapper;
using BookingAPI.Models;
using BookingAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BookingAPI.Controllers
{
    public class OdataMonthlyBookingController : ODataController
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public OdataMonthlyBookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        // GET /odata/Bookings
        [EnableQuery]
        public IQueryable<MonthlyBooking> Get()
        {
            return _bookingService.GetAllMonthlyBookingsAsQueryable();
        }
    }
}
