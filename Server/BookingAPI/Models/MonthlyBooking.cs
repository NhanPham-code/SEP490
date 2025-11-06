using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPI.Models
{
    public class MonthlyBooking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Stadium")]
        public int StadiumId { get; set; }

        [ForeignKey("Discount")]
        public int? DiscountId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(10,2)")]
        public decimal? OriginalPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? TotalPrice { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        public string? PaymentMethod { get; set; }

        public string? Note { get; set; }

        public int TotalHour { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        // Navigation property for the list of associated Bookings
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}