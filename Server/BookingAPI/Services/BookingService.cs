using AutoMapper;
using BookingAPI.DTOs;
using BookingAPI.Models;
using BookingAPI.Repository.Interface;
using BookingAPI.Services.Interface;

namespace BookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingDetailRepository _bookingDetailRepository;
        private readonly IMapper _mapper;

        public BookingService(
            IBookingRepository bookingRepository,
            IBookingDetailRepository bookingDetailRepository,
            IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _bookingDetailRepository = bookingDetailRepository;
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
    }
}
