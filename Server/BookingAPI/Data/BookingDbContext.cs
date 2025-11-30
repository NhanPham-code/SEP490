using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingAPI.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<MonthlyBooking> MonthlyBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasMany(b => b.BookingDetails)
                .WithOne(d => d.Booking)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MonthlyBooking>()
                .HasMany(m => m.Bookings)
                .WithOne(b => b.MonthlyBooking)
                .HasForeignKey(b => b.MonthlyBookingId)
                .OnDelete(DeleteBehavior.SetNull);

            // Ngày hiện tại để seed data
            var currentDate = new DateTime(2025, 11, 30, 10, 41, 13);
            var random = new Random(42);
            var ownerIds = new List<int> { 2, 3, 4 };
            var customerIds = new List<int> { 5, 6, 7, 8 };

            // Dữ liệu sân
            var stadiumData = new List<(int StadiumId, int CourtId, decimal Price, int OwnerId, int OpenTime, int CloseTime)>
            {
                (1, 1, 300000, 3, 8, 22), (1, 2, 200000, 3, 8, 22), (1, 3, 200000, 3, 8, 22),
                (2, 4, 50000, 3, 7, 21), (2, 5, 50000, 3, 7, 21),
                (3, 6, 100000, 4, 8, 23), (3, 7, 100000, 4, 8, 23),
                (4, 8, 150000, 4, 6, 22),
                (5, 9, 70000, 4, 9, 21), (5, 10, 70000, 4, 9, 21),
                (6, 11, 500000, 2, 6, 23),
                (8, 12, 120000, 3, 7, 22), (8, 13, 120000, 3, 7, 22),
                (9, 14, 60000, 3, 8, 21), (9, 15, 60000, 3, 8, 21),
                (10, 16, 150000, 3, 8, 22),
                (11, 17, 80000, 2, 9, 23),
                (13, 18, 75000, 2, 8, 22),
                (14, 19, 280000, 2, 7, 23), (14, 20, 180000, 2, 7, 23), (14, 21, 180000, 2, 7, 23),
                (15, 22, 110000, 3, 8, 22),
                (16, 23, 100000, 4, 8, 21),
                (17, 24, 50000, 2, 9, 21), (17, 25, 70000, 2, 9, 21),
                (18, 26, 250000, 2, 6, 22), (18, 27, 150000, 2, 6, 22),
                (19, 28, 90000, 3, 8, 23),
                (20, 29, 80000, 3, 8, 22),
                (22, 30, 100000, 4, 7, 21),
                (23, 31, 70000, 4, 8, 21), (23, 32, 70000, 4, 8, 21),
                (24, 33, 150000, 3, 8, 22),
                (25, 34, 450000, 2, 6, 23), (25, 35, 300000, 2, 6, 23), (25, 36, 300000, 2, 6, 23),
                (26, 37, 120000, 2, 7, 22), (26, 38, 120000, 2, 7, 22), (26, 39, 120000, 2, 7, 22), (26, 40, 120000, 2, 7, 22),
                (27, 41, 95000, 4, 9, 22), (27, 42, 95000, 4, 9, 22)
            };

            // Quan hệ sân cha-con (sân ghép)
            var courtRelations = new List<(int ParentCourtId, int ChildCourtId)>
            {
                (1, 2), (1, 3),
                (19, 20), (19, 21),
                (34, 35), (34, 36)
            };

            var monthlyBookings = new List<MonthlyBooking>();
            var bookings = new List<Booking>();
            var bookingDetails = new List<BookingDetail>();
            int monthlyBookingIdCounter = 1, bookingIdCounter = 1, detailIdCounter = 1;

            // Helper: random CreatedById cho DAILY BOOKING
            Func<int, int> getRandomCreatedByIdForDaily = (stadiumOwnerId) =>
            {
                return random.Next(2) == 0 ? 0 : stadiumOwnerId;
            };

            // Helper: xác định status dựa trên ngày
            Func<string, DateTime, string> getFinalStatus = (initialStatus, bookingDate) =>
            {
                if (initialStatus == "cancelled")
                {
                    return "cancelled";
                }
                else if (bookingDate.Date < currentDate.Date)
                {
                    return "completed";
                }
                else
                {
                    return initialStatus;
                }
            };

            // Helper: tính TotalPrice (nếu cancelled thì = 0)
            Func<string, decimal, decimal> getTotalPrice = (status, originalPrice) =>
            {
                return status == "cancelled" ? 0 : originalPrice;
            };

            // Helper: tạo BookingDetails với courtId CỐ ĐỊNH
            Action<int, int, DateTime, int> createBookingDetailsFixed = (bookingId, courtId, bookingDate, startHour) =>
            {
                var children = courtRelations.Where(r => r.ParentCourtId == courtId).ToList();
                if (children.Any())
                {
                    foreach (var relation in children)
                    {
                        bookingDetails.Add(new BookingDetail
                        {
                            Id = detailIdCounter++,
                            BookingId = bookingId,
                            CourtId = relation.ChildCourtId,
                            StartTime = bookingDate.Date.AddHours(startHour),
                            EndTime = bookingDate.Date.AddHours(startHour + 2)
                        });
                    }
                }
                else
                {
                    bookingDetails.Add(new BookingDetail
                    {
                        Id = detailIdCounter++,
                        BookingId = bookingId,
                        CourtId = courtId,
                        StartTime = bookingDate.Date.AddHours(startHour),
                        EndTime = bookingDate.Date.AddHours(startHour + 2)
                    });
                }
            };

            // Danh sách các tháng cần tạo dữ liệu
            var monthsToGenerate = new List<(int Month, int Year)>();
            for (int m = 1; m <= 12; m++)
            {
                monthsToGenerate.Add((m, 2025));
            }
            monthsToGenerate.Add((1, 2026));
            monthsToGenerate.Add((2, 2026));

            foreach (var ownerId in ownerIds)
            {
                var ownerStadiums = stadiumData.Where(s => s.OwnerId == ownerId).ToList();
                if (!ownerStadiums.Any()) continue;

                // ========== MONTHLY BOOKINGS ==========
                foreach (var (month, year) in monthsToGenerate)
                {
                    var courtInfo = ownerStadiums[random.Next(ownerStadiums.Count)];
                    var customerId = customerIds[random.Next(customerIds.Count)];

                    int latestStartHour = courtInfo.CloseTime - 2;
                    int startHour = random.Next(courtInfo.OpenTime, latestStartHour + 1);

                    decimal originalMonthlyPrice = courtInfo.Price * 2 * 4;
                    string initialStatus = random.Next(10) < 8 ? "accepted" : "cancelled";

                    var monthEndDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
                    string parentFinalStatus = getFinalStatus(initialStatus, monthEndDate);

                    // TotalPrice = 0 nếu cancelled
                    decimal parentTotalPrice = getTotalPrice(parentFinalStatus, originalMonthlyPrice);

                    monthlyBookings.Add(new MonthlyBooking
                    {
                        Id = monthlyBookingIdCounter,
                        UserId = customerId,
                        StadiumId = courtInfo.StadiumId,
                        CreatedAt = currentDate.AddDays(-30),
                        UpdatedAt = currentDate.AddDays(-1),
                        OriginalPrice = originalMonthlyPrice,
                        TotalPrice = parentTotalPrice,
                        Status = parentFinalStatus,
                        PaymentMethod = "vnpay_100",
                        Note = $"Lịch đặt tháng {month}/{year}",
                        TotalHour = 8,
                        StartTime = new TimeSpan(startHour, 0, 0),
                        EndTime = new TimeSpan(startHour + 2, 0, 0),
                        Month = month,
                        Year = year
                    });

                    // Tạo 4 booking con
                    for (int week = 0; week < 4; week++)
                    {
                        int day = (week * 7) + 1;
                        if (day > DateTime.DaysInMonth(year, month))
                            day = DateTime.DaysInMonth(year, month);

                        var bookingDate = new DateTime(year, month, day);
                        string childFinalStatus = getFinalStatus(initialStatus, bookingDate);

                        decimal originalChildPrice = originalMonthlyPrice / 4;
                        decimal childTotalPrice = getTotalPrice(childFinalStatus, originalChildPrice);

                        bookings.Add(new Booking
                        {
                            Id = bookingIdCounter,
                            UserId = customerId,
                            CreatedById = 0,
                            Status = childFinalStatus,
                            Date = bookingDate,
                            TotalPrice = childTotalPrice,
                            OriginalPrice = originalChildPrice,
                            Note = "Lịch con của booking tháng",
                            PaymentMethod = "vnpay_100",
                            CreatedAt = currentDate.AddDays(-30),
                            UpdatedAt = currentDate.AddDays(-1),
                            StadiumId = courtInfo.StadiumId,
                            MonthlyBookingId = monthlyBookingIdCounter
                        });

                        createBookingDetailsFixed(bookingIdCounter, courtInfo.CourtId, bookingDate, startHour);
                        bookingIdCounter++;
                    }
                    monthlyBookingIdCounter++;
                }

                // ========== DAILY BOOKINGS (quá khứ và tương lai gần) ==========
                for (int i = 0; i < 60; i++)
                {
                    var courtInfo = ownerStadiums[random.Next(ownerStadiums.Count)];
                    var customerId = customerIds[random.Next(customerIds.Count)];
                    var createdById = getRandomCreatedByIdForDaily(courtInfo.OwnerId);

                    var bookingDate = currentDate.AddDays(random.Next(-90, 61));

                    int latestStartHour = courtInfo.CloseTime - 2;
                    int startHour = random.Next(courtInfo.OpenTime, latestStartHour + 1);

                    decimal originalPrice = courtInfo.Price * 2;
                    string initialStatus = random.Next(10) < 8 ? "accepted" : "cancelled";
                    string finalStatus = getFinalStatus(initialStatus, bookingDate);
                    decimal totalPrice = getTotalPrice(finalStatus, originalPrice);

                    bookings.Add(new Booking
                    {
                        Id = bookingIdCounter,
                        UserId = customerId,
                        CreatedById = createdById,
                        Status = finalStatus,
                        Date = bookingDate,
                        TotalPrice = totalPrice,
                        OriginalPrice = originalPrice,
                        Note = createdById == 0 ? "Khách đặt online" : "Chủ sân tạo hộ",
                        PaymentMethod = "vnpay_100",
                        CreatedAt = bookingDate.AddDays(-5),
                        UpdatedAt = bookingDate.AddDays(-1),
                        StadiumId = courtInfo.StadiumId,
                        MonthlyBookingId = null
                    });
                    createBookingDetailsFixed(bookingIdCounter, courtInfo.CourtId, bookingDate, startHour);
                    bookingIdCounter++;
                }

                // ========== DAILY BOOKINGS (tương lai xa - 2026) ==========
                for (int i = 0; i < 20; i++)
                {
                    var courtInfo = ownerStadiums[random.Next(ownerStadiums.Count)];
                    var customerId = customerIds[random.Next(customerIds.Count)];
                    var createdById = getRandomCreatedByIdForDaily(courtInfo.OwnerId);

                    int targetMonth = random.Next(1, 3);
                    int targetDay = random.Next(1, DateTime.DaysInMonth(2026, targetMonth) + 1);
                    var bookingDate = new DateTime(2026, targetMonth, targetDay);

                    int latestStartHour = courtInfo.CloseTime - 2;
                    int startHour = random.Next(courtInfo.OpenTime, latestStartHour + 1);

                    decimal originalPrice = courtInfo.Price * 2;
                    string status = random.Next(10) < 7 ? "accepted" : "waiting";
                    decimal totalPrice = getTotalPrice(status, originalPrice);

                    bookings.Add(new Booking
                    {
                        Id = bookingIdCounter,
                        UserId = customerId,
                        CreatedById = createdById,
                        Status = status,
                        Date = bookingDate,
                        TotalPrice = totalPrice,
                        OriginalPrice = originalPrice,
                        Note = createdById == 0 ? "Khách đặt online" : "Chủ sân tạo hộ",
                        PaymentMethod = "vnpay_100",
                        CreatedAt = currentDate,
                        UpdatedAt = currentDate,
                        StadiumId = courtInfo.StadiumId,
                        MonthlyBookingId = null
                    });
                    createBookingDetailsFixed(bookingIdCounter, courtInfo.CourtId, bookingDate, startHour);
                    bookingIdCounter++;
                }

                // ========== WAITING BOOKINGS ==========
                for (int k = 0; k < 3; k++)
                {
                    var courtInfo = ownerStadiums[random.Next(ownerStadiums.Count)];
                    var customerId = customerIds[random.Next(customerIds.Count)];
                    var createdById = getRandomCreatedByIdForDaily(courtInfo.OwnerId);
                    var bookingDate = currentDate.AddDays(random.Next(1, 45));

                    int latestStartHour = courtInfo.CloseTime - 2;
                    int startHour = random.Next(courtInfo.OpenTime, latestStartHour + 1);

                    decimal originalPrice = courtInfo.Price * 2;
                    string status = random.Next(10) < 6 ? "accepted" : "waiting";
                    decimal totalPrice = getTotalPrice(status, originalPrice);

                    bookings.Add(new Booking
                    {
                        Id = bookingIdCounter,
                        UserId = customerId,
                        CreatedById = createdById,
                        Status = status,
                        Date = bookingDate,
                        TotalPrice = totalPrice,
                        OriginalPrice = originalPrice,
                        Note = createdById == 0 ? null : "Đặt qua điện thoại",
                        PaymentMethod = "vnpay_100",
                        CreatedAt = currentDate,
                        UpdatedAt = currentDate,
                        StadiumId = courtInfo.StadiumId,
                        MonthlyBookingId = null
                    });
                    createBookingDetailsFixed(bookingIdCounter, courtInfo.CourtId, bookingDate, startHour);
                    bookingIdCounter++;
                }
            }

            modelBuilder.Entity<MonthlyBooking>().HasData(monthlyBookings);
            modelBuilder.Entity<Booking>().HasData(bookings);
            modelBuilder.Entity<BookingDetail>().HasData(bookingDetails);
        }
    }
}