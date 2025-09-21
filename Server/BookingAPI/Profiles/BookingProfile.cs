using AutoMapper;
using BookingAPI.DTOs;
using BookingAPI.Models;

namespace BookingAPI.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            // Booking mappings
            CreateMap<BookingCreateDto, Booking>();
            CreateMap<Booking, BookingReadDto>();
            CreateMap<BookingUpdateDto, Booking>();
            CreateMap<Booking, BookingUpdateDto>();

            // BookingDetail mappings
            CreateMap<BookingDetailCreateDto, BookingDetail>();
            CreateMap<BookingDetail, BookingDetailReadDto>();
            CreateMap<BookingDetailUpdateDto, BookingDetail>();

            CreateMap<MonthlyBookingCreateDto, MonthlyBooking>();
            // For reading a MonthlyBooking
            CreateMap<MonthlyBooking, MonthlyBookingReadDto>();

            // For updating a MonthlyBooking
            CreateMap<MonthlyBookingUpdateDto, MonthlyBooking>();
            CreateMap<MonthlyBooking, MonthlyBookingUpdateDto>();

        }
    }
}
