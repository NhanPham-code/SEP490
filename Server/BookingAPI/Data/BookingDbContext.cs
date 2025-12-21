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

            // Ngày hiện tại (16/12/2025)
            var currentDate = new DateTime(2025, 12, 21, 10, 0, 0);
            var random = new Random(42);
            var ownerIds = new List<int> { 2, 3, 4 };
            var customerIds = new List<int> { 5, 6, 7, 8 };

            // Dữ liệu sân
            var stadiumData = new List<(int StadiumId, int CourtId, decimal Price, int OwnerId, int OpenTime, int CloseTime)>
            {
                // Stadium 1 - Sân Bóng Phi Long (Owner 3) - Open 6-22
                (1, 1, 300000m, 3, 6, 22),  // Sân 7 người
                (1, 2, 200000m, 3, 6, 22),  // Sân 5 người A
                (1, 3, 200000m, 3, 6, 22),  // Sân 5 người B

                // Stadium 2 - Sân Cầu Lông Quang Sport (Owner 3) - Open 8-22
                (2, 4, 50000m, 3, 8, 22),   // Sân A
                (2, 5, 50000m, 3, 8, 22),   // Sân B (IsAvailable = false nhưng vẫn để gen data test)

                // Stadium 3 - Sân Tennis 6 Đời 6 (Owner 4) - Open 5-22
                (3, 6, 100000m, 4, 5, 22),  // Sân Số 1
                (3, 7, 100000m, 4, 5, 22),  // Sân Số 2

                // Stadium 4 - Sân bóng rổ DNC (Owner 4) - Open 7-21
                (4, 8, 150000m, 4, 7, 21),  // Sân chính

                // Stadium 5 - Sân Cầu Lông Tambo (Owner 4) - Open 5-21:30
                (5, 9, 70000m, 4, 5, 21),   // Sân 1
                (5, 10, 70000m, 4, 5, 21),  // Sân 2

                // Stadium 6 - Sân Vận Động Cần Thơ (Owner 2) - Open 6-21
                (6, 11, 500000m, 2, 6, 21), // Sân Chính (sân 11 người)

                // Stadium 8 - Sân Tennis 586 (Owner 3) - Open 5:30-21:30
                (8, 12, 120000m, 3, 5, 21), // Sân 1
                (8, 13, 120000m, 3, 5, 21), // Sân 2

                // Stadium 9 - Sân Cầu Lông Bưu Điện (Owner 3) - Open 7-22
                (9, 14, 60000m, 3, 7, 22),  // Sân Số 1
                (9, 15, 60000m, 3, 7, 22),  // Sân Số 2

                // Stadium 10 - Sân Tennis Mường Thanh (Owner 3) - Open 6-23
                (10, 16, 150000m, 3, 6, 23), // Sân Đơn

                // Stadium 11 - Sân bóng chuyền 586 (Owner 2) - Open 5-21
                (11, 17, 80000m, 2, 5, 21), // Sân Chính

                // Stadium 13 - Sân Cầu Lông Hoàng Long (Owner 2) - Open 7-22
                (13, 18, 75000m, 2, 7, 22), // Sân Số 3

                // Stadium 14 - Sân bóng đá Anh Tuấn (Owner 2) - Open 6-22:30
                (14, 19, 280000m, 2, 6, 22), // Sân 7 người 1 (parent)
                (14, 20, 180000m, 2, 6, 22), // Sân 5 người A (child)
                (14, 21, 180000m, 2, 6, 22), // Sân 5 người B (child)

                // Stadium 15 - Sân Tennis Công An (Owner 3) - Open 5:30-21
                (15, 22, 110000m, 3, 5, 21), // Sân Công an 1

                // Stadium 16 - Sân bóng rổ WestSide (Owner 4) - Open 7-21
                (16, 23, 100000m, 4, 7, 21), // Sân chính

                // Stadium 17 - Nhà Thi Đấu Vị Thanh (Owner 2) - Open 8-21
                (17, 24, 50000m, 2, 8, 21),  // Sân A (Cầu lông)
                (17, 25, 70000m, 2, 8, 21),  // Sân Bóng Chuyền

                // Stadium 18 - Sân bóng đá Vị Thanh (Owner 2) - Open 6-22
                (18, 26, 250000m, 2, 6, 22), // Sân 7 người 1
                (18, 27, 150000m, 2, 6, 22), // Sân 5 người

                // Stadium 19 - Sân Tennis Phú Hưng (Owner 3) - Open 6-22
                (19, 28, 90000m, 3, 6, 22),  // Sân 1

                // Stadium 20 - Nhà Thi Đấu Vĩnh Long (Owner 3) - Open 7-21:30
                (20, 29, 80000m, 3, 7, 21),  // Sân bóng chuyền

                // Stadium 22 - Sân Pickleball Cần Thơ (Owner 4) - Open 8-21
                (22, 30, 100000m, 4, 8, 21), // Sân Pickleball 1

                // Stadium 23 - Sân Cầu Lông Win Sport (Owner 4) - Open 7-22
                (23, 31, 70000m, 4, 7, 22),  // Sân 1
                (23, 32, 70000m, 4, 7, 22),  // Sân 2

                // Stadium 24 - Sân bóng chuyền bãi biển (Owner 3) - Open 8-18
                (24, 33, 150000m, 3, 8, 18), // Sân chính

                // Stadium 25 - Sân bóng đá Đại học Cần Thơ (Owner 2) - Open 6-20
                (25, 34, 450000m, 2, 6, 20), // Sân 11 người (parent)
                (25, 35, 300000m, 2, 6, 20), // Sân 7 người A (child)
                (25, 36, 300000m, 2, 6, 20), // Sân 7 người B (child)

                // Stadium 26 - Sân Pickleball Ninh Kiều (Owner 2) - Open 6-22
                (26, 37, 120000m, 2, 6, 22), // Sân 1
                (26, 38, 120000m, 2, 6, 22), // Sân 2
                (26, 39, 120000m, 2, 6, 22), // Sân 3
                (26, 40, 120000m, 2, 6, 22), // Sân 4

                // Stadium 27 - Sân Pickleball Cái Răng (Owner 4) - Open 5:30-21:30
                (27, 41, 95000m, 4, 5, 21),  // Sân A
                (27, 42, 95000m, 4, 5, 21)   // Sân B
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

            // Helper:  random CreatedById cho DAILY BOOKING
            Func<int, int> getRandomCreatedByIdForDaily = (stadiumOwnerId) =>
            {
                return random.Next(2) == 0 ? 0 : stadiumOwnerId;
            };

            // Helper: random status ban đầu (chỉ 3 loại:  accepted, payfail, cancelled)
            Func<string> getRandomInitialStatus = () =>
            {
                int rand = random.Next(10);
                if (rand < 7) return "accepted";      // 70%
                else if (rand < 9) return "payfail";  // 20%
                else return "cancelled";              // 10%
            };

            // Helper: xác định final status cho Booking NGÀY (không có parent)
            // Nếu accepted và Date < currentDate => completed
            Func<string, DateTime, string> getFinalStatusForDaily = (initialStatus, playDate) =>
            {
                if (initialStatus == "accepted" && playDate.Date < currentDate.Date)
                {
                    return "completed";
                }
                return initialStatus;
            };

            // Helper: xác định final status cho Booking CON (có parent MonthlyBooking)
            // Phải đồng bộ với parent:  nếu parent cancelled/payfail => con cũng vậy
            // Nếu parent accepted và ngày chơi < currentDate => completed
            Func<string, DateTime, string> getFinalStatusForChild = (parentStatus, playDate) =>
            {
                // Nếu parent là cancelled hoặc payfail => con cũng giữ nguyên status đó
                if (parentStatus == "cancelled" || parentStatus == "payfail")
                {
                    return parentStatus;
                }
                // Nếu parent là accepted/completed, kiểm tra ngày chơi
                if (playDate.Date < currentDate.Date)
                {
                    return "completed";
                }
                return "accepted";
            };

            // Helper: xác định final status cho MonthlyBooking (parent)
            // Dựa trên ngày cuối cùng của tháng đó
            Func<string, DateTime, string> getFinalStatusForMonthly = (initialStatus, monthEndDate) =>
            {
                // Nếu cancelled hoặc payfail => giữ nguyên
                if (initialStatus == "cancelled" || initialStatus == "payfail")
                {
                    return initialStatus;
                }
                // Nếu accepted và tháng đó đã qua => completed
                if (initialStatus == "accepted" && monthEndDate.Date < currentDate.Date)
                {
                    return "completed";
                }
                return initialStatus;
            };

            // Helper: tính TotalPrice cho MonthlyBooking (cancelled = 0)
            Func<string, decimal, decimal> getMonthlyTotalPrice = (status, originalPrice) =>
            {
                return status == "cancelled" ? 0 : originalPrice;
            };

            // Helper: tạo CreatedAt không vượt quá currentDate
            Func<DateTime, DateTime> getSafeCreatedAt = (referenceDate) =>
            {
                var createdAt = referenceDate.AddDays(-random.Next(1, 31));
                if (createdAt > currentDate)
                {
                    createdAt = currentDate.AddDays(-random.Next(1, 10));
                }
                return createdAt;
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
                    decimal originalMonthlyPrice = courtInfo.Price * 2 * 4; // 2 giờ x 4 tuần


                    string initialStatus = getRandomInitialStatus();

                    // Tính 4 ngày chơi
                    var childDates = new List<DateTime>();
                    for (int week = 0; week < 4; week++)
                    {
                        int day = (week * 7) + 1;
                        if (day > DateTime.DaysInMonth(year, month))
                            day = DateTime.DaysInMonth(year, month);
                        childDates.Add(new DateTime(year, month, day));
                    }

                    // Tính parentStatus mới
                    string parentStatus;
                    if (initialStatus == "cancelled" || initialStatus == "payfail")
                    {
                        parentStatus = initialStatus;
                    }
                    else
                    {
                        bool allCompleted = childDates.All(d => d.Date < currentDate.Date);
                        parentStatus = allCompleted ? "completed" : "accepted";
                    }

                    // TotalPrice
                    decimal monthlyTotalPrice = (initialStatus == "cancelled") ? 0m : originalMonthlyPrice;

                    var baseCreatedAt = getSafeCreatedAt(new DateTime(year, month, 1));

                    monthlyBookings.Add(new MonthlyBooking
                    {
                        Id = monthlyBookingIdCounter,
                        UserId = customerId,
                        StadiumId = courtInfo.StadiumId,
                        Status = parentStatus,
                        TotalPrice = monthlyTotalPrice,
                        OriginalPrice = originalMonthlyPrice,
                        CreatedAt = baseCreatedAt,
                        UpdatedAt = baseCreatedAt.AddDays(random.Next(0, 5)),
                        PaymentMethod = "vnpay_100",
                        Note = $"Lịch đặt tháng {month}/{year}",
                        TotalHour = 8,
                        StartTime = new TimeSpan(startHour, 0, 0),
                        EndTime = new TimeSpan(startHour + 2, 0, 0),
                        Month = month,
                        Year = year
                    });

                    // Tạo 4 booking con - STATUS BẮT BUỘC ĐỒNG BỘ THEO PARENT
                    for (int week = 0; week < 4; week++)
                    {
                        int day = (week * 7) + 1;
                        if (day > DateTime.DaysInMonth(year, month))
                            day = DateTime.DaysInMonth(year, month);

                        var bookingDate = new DateTime(year, month, day);

                        // Status child: đồng bộ với parent, chỉ chuyển completed nếu parent không phải cancelled/payfail và ngày chơi đã qua
                        string childStatus;
                        if (parentStatus == "cancelled" || parentStatus == "payfail")
                        {
                            childStatus = parentStatus; // bắt buộc cùng
                        }
                        else // parent là accepted hoặc completed
                        {
                            childStatus = (bookingDate.Date < currentDate.Date) ? "completed" : "accepted";
                        }

                        decimal childTotalPrice = originalMonthlyPrice / 4; // luôn giữ nguyên

                        var childCreatedAt = baseCreatedAt.AddDays(random.Next(0, 8));
                        if (childCreatedAt > currentDate) childCreatedAt = currentDate.AddDays(-random.Next(1, 5));

                        bookings.Add(new Booking
                        {
                            Id = bookingIdCounter,
                            UserId = customerId,
                            CreatedById = 0,
                            Status = childStatus,
                            TotalPrice = childTotalPrice,
                            OriginalPrice = originalMonthlyPrice / 4,
                            CreatedAt = childCreatedAt,
                            UpdatedAt = childCreatedAt.AddDays(random.Next(0, 3)),
                            Date = bookingDate,
                            Note = "Lịch con của booking tháng",
                            PaymentMethod = "vnpay_100",
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
                    string initialStatus = getRandomInitialStatus();
                    string finalStatus = getFinalStatusForDaily(initialStatus, bookingDate);

                    // Daily Booking:  TotalPrice giữ nguyên
                    decimal totalPrice = originalPrice;

                    // CreatedAt không vượt quá currentDate
                    var dailyCreatedAt = getSafeCreatedAt(bookingDate);

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
                        CreatedAt = dailyCreatedAt,
                        UpdatedAt = dailyCreatedAt.AddDays(random.Next(0, 3)),
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
                    string initialStatus = getRandomInitialStatus();
                    string finalStatus = getFinalStatusForDaily(initialStatus, bookingDate);

                    decimal totalPrice = originalPrice;

                    var futureCreatedAt = currentDate.AddDays(-random.Next(0, 10));

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
                        CreatedAt = futureCreatedAt,
                        UpdatedAt = futureCreatedAt,
                        StadiumId = courtInfo.StadiumId,
                        MonthlyBookingId = null
                    });
                    createBookingDetailsFixed(bookingIdCounter, courtInfo.CourtId, bookingDate, startHour);
                    bookingIdCounter++;
                }

                // ========== ADDITIONAL BOOKINGS ==========
                for (int k = 0; k < 3; k++)
                {
                    var courtInfo = ownerStadiums[random.Next(ownerStadiums.Count)];
                    var customerId = customerIds[random.Next(customerIds.Count)];
                    var createdById = getRandomCreatedByIdForDaily(courtInfo.OwnerId);
                    var bookingDate = currentDate.AddDays(random.Next(1, 45));

                    int latestStartHour = courtInfo.CloseTime - 2;
                    int startHour = random.Next(courtInfo.OpenTime, latestStartHour + 1);

                    decimal originalPrice = courtInfo.Price * 2;
                    string initialStatus = getRandomInitialStatus();
                    string finalStatus = getFinalStatusForDaily(initialStatus, bookingDate);

                    decimal totalPrice = originalPrice;

                    var additionalCreatedAt = currentDate.AddDays(-random.Next(0, 5));

                    bookings.Add(new Booking
                    {
                        Id = bookingIdCounter,
                        UserId = customerId,
                        CreatedById = createdById,
                        Status = finalStatus,
                        Date = bookingDate,
                        TotalPrice = totalPrice,
                        OriginalPrice = originalPrice,
                        Note = createdById == 0 ? null : "Đặt qua điện thoại",
                        PaymentMethod = "vnpay_100",
                        CreatedAt = additionalCreatedAt,
                        UpdatedAt = additionalCreatedAt,
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