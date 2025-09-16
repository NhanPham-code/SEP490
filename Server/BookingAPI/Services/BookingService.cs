using AutoMapper;
using BookingAPI.DTOs;
using BookingAPI.Models;
using BookingAPI.Repository;
using BookingAPI.Repository.Interface;
using BookingAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace BookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingDetailRepository _bookingDetailRepository;
        private readonly IMonthlyBookingRepository _monthlyBookingRepository;
        private readonly IMapper _mapper;

        public BookingService(
            IBookingRepository bookingRepository,
            IBookingDetailRepository bookingDetailRepository,
            IMonthlyBookingRepository monthlyBookingRepository,
            IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _bookingDetailRepository = bookingDetailRepository;
            _monthlyBookingRepository = monthlyBookingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingReadDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();
            return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
        }

        public async Task<BookingReadDto?> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);
            return booking == null ? null : _mapper.Map<BookingReadDto>(booking);
        }

        public async Task<BookingReadDto> CreateBookingAsync(BookingCreateDto bookingCreateDto)
        {
            var booking = _mapper.Map<Booking>(bookingCreateDto);

            // Map booking details
            /*foreach (var detailDto in bookingCreateDto.BookingDetails)
            {
                var bookingDetail = _mapper.Map<BookingDetail>(detailDto);
                booking.BookingDetails.Add(bookingDetail);
            }*/

            var createdBooking = await _bookingRepository.CreateBookingAsync(booking);
            return _mapper.Map<BookingReadDto>(createdBooking);
        }

        public async Task<BookingUpdateDto?> UpdateBookingAsync(int id, BookingUpdateDto bookingUpdateDto)
        {
            var existingBooking = await _bookingRepository.GetBookingByIdAsync(id);
            if (existingBooking == null) return null;

            _mapper.Map(bookingUpdateDto, existingBooking);

            // Update booking details
/*            existingBooking.BookingDetails.Clear();
            foreach (var detailDto in bookingUpdateDto.BookingDetails)
            {
                var bookingDetail = _mapper.Map<BookingDetail>(detailDto);
                bookingDetail.BookingId = id;
                existingBooking.BookingDetails.Add(bookingDetail);
            }*/

            var updatedBooking = await _bookingRepository.UpdateBookingAsync(existingBooking);
            return _mapper.Map<BookingUpdateDto>(updatedBooking);
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            return await _bookingRepository.DeleteBookingAsync(id);
        }

        public async Task<bool> BookingExistsAsync(int id)
        {
            return await _bookingRepository.BookingExistsAsync(id);
        }

        // OData get all bookings queryable
        public IQueryable<Booking> GetAllBookingsAsQueryable()
        {
            return _bookingRepository.GetAllBookingsAsQueryable();
        }

        public async Task<IEnumerable<BookingReadDto>> GetBookingsByDateRangeAndHourAsync(int year, int month, IEnumerable<int> days, TimeSpan startTime, TimeSpan endTime)
        {
            var bookings = await _bookingRepository.GetBookingsByDateRangeAndHourAsync(year, month, days, startTime, endTime);

            return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
        }

        public async Task<IEnumerable<BookingReadDto>> GetBookingsByCourtIdsAndHourAsync(IEnumerable<int> courtIds, int year, int month, TimeSpan startTime, TimeSpan endTime)
        {
            var bookings = await _bookingRepository.GetBookingsByCourtIdsAndHourAsync(courtIds, year, month, startTime, endTime);

            return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
        }

        public async Task<MonthlyBookingReadDto> CreateMonthlyBookingAsync([FromForm] MonthlyBookingCreateDto monthlyBookingCreateDto)
        {
            if (!TimeSpan.TryParseExact(monthlyBookingCreateDto.StartTime, "hh\\:mm", CultureInfo.InvariantCulture, out var startTime) ||
                !TimeSpan.TryParseExact(monthlyBookingCreateDto.EndTime, "hh\\:mm", CultureInfo.InvariantCulture, out var endTime))
            {
                throw new ArgumentException("Invalid time format. Use HH:mm.");
            }

            var monthlyBooking = _mapper.Map<MonthlyBooking>(monthlyBookingCreateDto);
            monthlyBooking.StartTime = startTime;
            monthlyBooking.EndTime = endTime;
            monthlyBooking.TotalHour = (int)(endTime - startTime).TotalHours;

            foreach (var day in monthlyBookingCreateDto.Dates)
            {
                var bookingDate = new DateTime(monthlyBookingCreateDto.Year, monthlyBookingCreateDto.Month, day);

                var booking = new Booking
                {
                    UserId = monthlyBooking.UserId,
                    StadiumId = monthlyBooking.StadiumId,
                    DiscountId = monthlyBooking.DiscountId,
                    Date = bookingDate,
                    OriginalPrice = monthlyBooking.OriginalPrice / monthlyBookingCreateDto.Dates.Count, // Example price calculation
                    TotalPrice = monthlyBooking.TotalPrice / monthlyBookingCreateDto.Dates.Count, // Example price calculation
                    PaymentMethod = monthlyBooking.PaymentMethod,
                    Note = monthlyBooking.Note,
                    Status = "pending",
                };

                foreach (var courtId in monthlyBookingCreateDto.CourtIds)
                {
                    booking.BookingDetails.Add(new BookingDetail
                    {
                        CourtId = courtId,
                        StartTime = bookingDate.Add(startTime),
                        EndTime = bookingDate.Add(endTime)
                    });
                }

                monthlyBooking.Bookings.Add(booking);
            }

            var createdMonthlyBooking = await _monthlyBookingRepository.CreateMonthlyBookingAsync(monthlyBooking);

            var readDto = _mapper.Map<MonthlyBookingReadDto>(createdMonthlyBooking);
            readDto.BookingIds = createdMonthlyBooking.Bookings.Select(b => b.Id).ToList();

            return readDto;
        }

    }
}
