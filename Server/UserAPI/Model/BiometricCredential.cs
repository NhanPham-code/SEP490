using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserAPI.Model
{
    public class BiometricCredential
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Chuỗi token ngẫu nhiên, dài, và duy nhất dùng để xác thực.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Token { get; set; } = null!;

        /// <summary>
        /// (Tùy chọn nhưng rất khuyến khích) Một định danh duy nhất cho thiết bị của người dùng.
        /// Client sẽ gửi lên khi đăng ký.
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string DeviceId { get; set; } = null!;

        /// <summary>
        /// (Tùy chọn) Tên của thiết bị để người dùng dễ nhận biết, ví dụ: "iPhone 15 của Nhân".
        /// </summary>
        [MaxLength(100)]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Cờ để kích hoạt hoặc vô hiệu hóa tín vật này mà không cần xóa.
        /// </summary>
        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // --- Liên kết với User (Quan trọng nhất) ---
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
    }
}
