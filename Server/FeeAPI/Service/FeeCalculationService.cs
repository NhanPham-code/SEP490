using FeeAPI.DTOs;
using FeeAPI.Model;
using FeeAPI.Service.Interface;
using Microsoft.Extensions.Logging;

namespace FeeAPI.Service
{
    public class FeeCalculationService : IFeeCalculationService
    {
        private readonly IStadiumService _stadiumService;
        private readonly IBookingService _bookingService;
        private readonly IFeeService _feeService;
        private readonly ILogger<FeeCalculationService> _logger;

        private const decimal FeePercentage = 0.02m; // 2%

        public FeeCalculationService(
            IStadiumService stadiumService,
            IBookingService bookingService,
            IFeeService feeService,
            ILogger<FeeCalculationService> logger)
        {
            _stadiumService = stadiumService;
            _bookingService = bookingService;
            _feeService = feeService;
            _logger = logger;
        }

        public async Task GenerateFeesForPreviousMonthAsync()
        {
            var today = DateTime.UtcNow;
            var previousMonthDate = today.AddMonths(-1);
            int year = previousMonthDate.Year;
            int month = previousMonthDate.Month;

            _logger.LogInformation("Bắt đầu background job tự động tính phí cho tháng {Month}/{Year}.", month, year);
            await GenerateFeesAsync(year, month);
        }

        public async Task GenerateFeesAsync(int year, int month)
        {
            _logger.LogInformation("Bắt đầu quy trình tính phí cho tháng: {Month}/{Year}", month, year);

            try
            {
                // Bước 1: Lấy tất cả sân vận động từ StadiumAPI
                var odataResponseList = await _stadiumService.GetReadStadiumDTOsAsync();
                var allStadiums = odataResponseList.SelectMany(r => r.Value).ToList();

                if (!allStadiums.Any())
                {
                    _logger.LogWarning("Không tìm thấy sân vận động nào để tính phí.");
                    return;
                }
                _logger.LogInformation("Tìm thấy {Count} sân vận động.", allStadiums.Count);

                var stadiumIds = allStadiums.Select(s => s.Id).ToList();

                // Bước 2: Gọi BookingAPI để lấy doanh thu cho tất cả các sân
                var revenueRequest = new RevenueRequestDto { StadiumIds = stadiumIds, Year = year, Month = month };
                var revenueData = (await _bookingService.GetStadiumRevenuesAsync(revenueRequest)).ToDictionary(r => r.StadiumId);

                _logger.LogInformation("Đã nhận dữ liệu doanh thu cho {Count} sân.", revenueData.Count);

                // Bước 3: Tạo các đối tượng Fee và lưu vào DB
                int feesCreatedCount = 0;
                foreach (var stadium in allStadiums)
                {
                    revenueData.TryGetValue(stadium.Id, out var revenue);
                    decimal totalRevenue = revenue?.TotalRevenue ?? 0;
                    decimal feeAmount = totalRevenue * FeePercentage;

                    var newFee = new Fee
                    {
                        StadiumId = stadium.Id,
                        OwnerId = stadium.CreatedBy,
                        Month = month,
                        Year = year,
                        TotalRevenue = totalRevenue,
                        FeeAmount = feeAmount,
                        DueDate = new DateTime(year, month, 1).AddMonths(2).AddDays(-1), // Hạn chót là ngày cuối của tháng tiếp theo
                        IsPaid = false,
                        PaidDate = null,
                        Notes = "Tạo tự động bởi hệ thống."
                    };

                    await _feeService.CreateFeeAsync(newFee);
                    feesCreatedCount++;
                }

                _logger.LogInformation("Hoàn tất! Đã tạo thành công {Count} bản ghi phí cho tháng {Month}/{Year}.", feesCreatedCount, month, year);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Đã xảy ra lỗi nghiêm trọng trong quá trình tính phí cho tháng {Month}/{Year}.", month, year);
            }
        }
    }
}
