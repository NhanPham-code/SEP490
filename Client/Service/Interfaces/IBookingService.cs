using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTOs.BookingDTO;
using DTOs.BookingDTO.RevenueViewModel;

namespace Service.Interfaces
{
    public interface IBookingService
    {
        Task<(List<BookingReadDto> Data, int TotalCount)> GetBookingAsync(string accessToken, string queryString);
        Task<(List<MonthlyBookingReadDto> Data, int TotalCount)> GetMonthlyBookingAsync(string accessToken, string queryString);
        Task<MonthlyBookingWithBookingsDto?> GetMonthlyBookingDetailAsync(string accessToken, int monthlyBookingId);
        Task<BookingReadDto?> GetBookingDetailAsync(string accessToken, int bookingId);
        Task<BookingReadDto?> CreateBookingAsync(BookingCreateDto bookingCreateDto, string accessToken);
        Task<BookingReadDto?> CreateBookingByOwnerAsync(BookingCreateDto bookingDto, string accessToken);
        Task<List<BookingReadDto>> GetBookedCourtsAsync(int stadiumId, DateTime startTime, DateTime endTime);
        Task<List<BookingReadDto>> GetBookedCourtsAsync(int stadiumId, DateTime date);
        Task<List<BookingReadDto>> FilterByDateAndHour(int year, int month, List<int> days, int startHour, int endHour);
        Task<List<BookingReadDto>> FilterByCourtAndHour(List<int> courtIds, int year, int month, int startTime, int endTime);
        Task<BookingReadDto?> CreateMonthlyBookingAsync(MonthlyBookingCreateDto bookingDto, string accessToken);
        Task<BookingReadDto?> UpdateBookingAsync(int id, BookingUpdateDto bookingDto, string accessToken);
        Task<MonthlyBookingReadDto?> UpdateMonthlyBookingAsync(int id, MonthlyBookingUpdateDto bookingDto, string accessToken);
        Task<bool> CheckSlotsAvailabilityAsync(List<BookingSlotRequest> requestedSlots, string accessToken);
        Task<RevenueStatisticViewModel> GetRevenueStatisticsAsync(string accessToken, int year, int? month, int? day, int[]? stadiumIds);
        Task<List<StadiumBookingOverviewDto>> GetStadiumRevenueAsync(string accessToken, int page, int pageSize, int? year, int? month, int? day);
        Task<bool> HasCompletedBookingAtStadiumAsync(string accessToken, int stadiumId);
    }
}