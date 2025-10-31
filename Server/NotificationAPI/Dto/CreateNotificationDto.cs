using System.ComponentModel.DataAnnotations;

namespace NotificationAPI.Dto
{
    public class CreateNotificationDto
    {
        /**
         * UserId là id của user nhận thông báo
         */
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
    }
}
