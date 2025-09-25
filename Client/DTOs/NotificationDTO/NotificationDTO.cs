using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.NotificationDTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        /**
          * Type có thể là:
          * - "Booking.New"
          * - "Booking.Status"
          * - "Booking.Reminder"
          * - "Booking.Problem"
          * - "Discount.New"
          * - "Stadium.FavoriteNews"
          * - "Recruitment.JoinRequest" // user đăng ký tham gia, gửi chủ bài viết
          * - "Recruitment.Accepted"    // chủ bài viết đồng ý, gửi user đăng ký
          * - ... các loại khác nếu cần
        */
        [MaxLength(100)]
        public string? Type { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(500)]
        public string? Message { get; set; }

        [MaxLength(500)]
        public string? Parameters { get; set; } // JSON: {"bookingId":123,"customerName":"A"}

        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
