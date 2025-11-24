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


            var currentDate = new DateTime(2025, 11, 6, 10, 41, 13);
            var random = new Random();
            var ownerIds = new List<int> { 2, 3, 4 };
            var customerIds = new List<int> { 5, 6, 7, 8 };

            // Bước 1 & 2: Cập nhật cấu trúc và thêm dữ liệu giờ mở/đóng (OpenTime, CloseTime)
            // Giờ được biểu diễn dưới dạng số nguyên (ví dụ: 8 là 8h sáng, 22 là 10h tối)
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

            var courtRelations = new List<(int ParentCourtId, int ChildCourtId)> { (1, 2), (1, 3), (19, 20), (19, 21), (34, 35), (34, 36) };

            var monthlyBookings = new List<MonthlyBooking>();
            var bookings = new List<Booking>();
            var bookingDetails = new List<BookingDetail>();
            int monthlyBookingIdCounter = 1, bookingIdCounter = 1, detailIdCounter = 1;

            Action<int, int, DateTime, int, decimal> createBookingDetails = (bookingId, courtId, bookingDate, startHour, price) =>
            {
                var children = courtRelations.Where(r => r.ParentCourtId == courtId).ToList();
                if (children.Any())
                {
                    foreach (var relation in children)
                    {
                        bookingDetails.Add(new BookingDetail { Id = detailIdCounter++, BookingId = bookingId, CourtId = relation.ChildCourtId, StartTime = bookingDate.Date.AddHours(startHour), EndTime = bookingDate.Date.AddHours(startHour + 2) });
                    }
                }
                else
                {
                    bookingDetails.Add(new BookingDetail { Id = detailIdCounter++, BookingId = bookingId, CourtId = courtId, StartTime = bookingDate.Date.AddHours(startHour), EndTime = bookingDate.Date.AddHours(startHour + 2) });
                }
            };

            foreach (var ownerId in ownerIds)
            {
                var ownerStadiums = stadiumData.Where(s => s.OwnerId == ownerId).ToList();
                if (!ownerStadiums.Any()) continue;
                for (int month = 1; month <= 12; month++)
                {
                    var courtInfo = ownerStadiums[random.Next(ownerStadiums.Count)];
                    var customerId = customerIds[random.Next(customerIds.Count)];

                    // Bước 3: Tính toán `startHour` dựa trên giờ mở/đóng của sân
                    // Giờ bắt đầu cuối cùng có thể là (giờ đóng - 2)
                    int latestStartHour = courtInfo.CloseTime - 2;
                    int startHour = random.Next(courtInfo.OpenTime, latestStartHour + 1); // +1 vì upper bound của random.Next là exclusive

                    decimal monthlyPrice = courtInfo.Price * 2 * 4;
                    string initialStatus = random.Next(10) < 8 ? "accepted" : "cancelled";
                    var monthEndDate = new DateTime(2025, month, DateTime.DaysInMonth(2025, month));
                    string parentFinalStatus = (monthEndDate < currentDate && initialStatus == "accepted") ? "completed" : initialStatus;

                    monthlyBookings.Add(new MonthlyBooking
                    {
                        Id = monthlyBookingIdCounter,
                        UserId = customerId,
                        StadiumId = courtInfo.StadiumId,
                        CreatedAt = currentDate.AddDays(-30),
                        UpdatedAt = currentDate.AddDays(-1),
                        OriginalPrice = monthlyPrice,
                        TotalPrice = monthlyPrice,
                        Status = parentFinalStatus,
                        PaymentMethod = "vnpay_100",
                        Note = $"Lịch đặt tháng {month}/2025",
                        TotalHour = 8,
                        StartTime = new TimeSpan(startHour, 0, 0),
                        EndTime = new TimeSpan(startHour + 2, 0, 0),
                        Month = month,
                        Year = 2025
                    });

                    for (int week = 0; week < 4; week++)
                    {
                        var bookingDate = new DateTime(2025, month, (week * 7) + 1);
                        string childFinalStatus = (bookingDate < currentDate && initialStatus == "accepted") ? "completed" : initialStatus;
                        bookings.Add(new Booking
                        {
                            Id = bookingIdCounter,
                            UserId = customerId,
                            CreatedById = customerId,
                            Status = childFinalStatus,
                            Date = bookingDate,
                            TotalPrice = monthlyPrice / 4,
                            OriginalPrice = monthlyPrice / 4,
                            Note = "Lịch con của booking tháng",
                            PaymentMethod = "vnpay_100",
                            CreatedAt = currentDate.AddDays(-30),
                            UpdatedAt = currentDate.AddDays(-1),
                            StadiumId = courtInfo.StadiumId,
                            MonthlyBookingId = monthlyBookingIdCounter
                        });
                        createBookingDetails(bookingIdCounter, courtInfo.CourtId, bookingDate, startHour, monthlyPrice / 4);
                        bookingIdCounter++;
                    }
                    monthlyBookingIdCounter++;
                }

                for (int i = 0; i < 50; i++)
                {
                    var courtInfo = ownerStadiums[random.Next(ownerStadiums.Count)];
                    var customerId = customerIds[random.Next(customerIds.Count)];
                    var bookingDate = currentDate.AddDays(random.Next(-60, 31));

                    // Bước 3: Tính toán `startHour` dựa trên giờ mở/đóng của sân
                    int latestStartHour = courtInfo.CloseTime - 2;
                    int startHour = random.Next(courtInfo.OpenTime, latestStartHour + 1);

                    decimal price = courtInfo.Price * 2;
                    string initialStatus = random.Next(10) < 8 ? "accepted" : "cancelled";
                    string finalStatus = (bookingDate < currentDate && initialStatus == "accepted") ? "completed" : initialStatus;

                    bookings.Add(new Booking
                    {
                        Id = bookingIdCounter,
                        UserId = customerId,
                        CreatedById = customerId,
                        Status = finalStatus,
                        Date = bookingDate,
                        TotalPrice = price,
                        OriginalPrice = price,
                        Note = null,
                        PaymentMethod = "vnpay_100",
                        CreatedAt = bookingDate.AddDays(-5),
                        UpdatedAt = bookingDate.AddDays(-1),
                        StadiumId = courtInfo.StadiumId,
                        MonthlyBookingId = null
                    });
                    createBookingDetails(bookingIdCounter, courtInfo.CourtId, bookingDate, startHour, price);
                    bookingIdCounter++;
                }

                for (int k = 0; k < 2; k++)
                {
                    var courtInfo = ownerStadiums[random.Next(ownerStadiums.Count)];
                    var customerId = customerIds[random.Next(customerIds.Count)];
                    var bookingDate = currentDate.AddDays(random.Next(1, 31));

                    // Bước 3: Tính toán `startHour` dựa trên giờ mở/đóng của sân
                    int latestStartHour = courtInfo.CloseTime - 2;
                    int startHour = random.Next(courtInfo.OpenTime, latestStartHour + 1);

                    decimal price = courtInfo.Price * 2;
                    string status = random.Next(10) < 8 ? "accepted" : "waiting";

                    bookings.Add(new Booking
                    {
                        Id = bookingIdCounter,
                        UserId = customerId,
                        CreatedById = customerId,
                        Status = status,
                        Date = bookingDate,
                        TotalPrice = price,
                        OriginalPrice = price,
                        Note = null,
                        PaymentMethod = "vnpay_100",
                        CreatedAt = currentDate,
                        UpdatedAt = currentDate,
                        StadiumId = courtInfo.StadiumId,
                        MonthlyBookingId = null
                    });
                    createBookingDetails(bookingIdCounter, courtInfo.CourtId, bookingDate, startHour, price);
                    bookingIdCounter++;
                }
            }

            modelBuilder.Entity<MonthlyBooking>().HasData(monthlyBookings);
            modelBuilder.Entity<Booking>().HasData(bookings);
            modelBuilder.Entity<BookingDetail>().HasData(bookingDetails);
        }
    }
}