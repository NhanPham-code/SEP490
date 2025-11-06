using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingAPI.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public int CreatedById { get; set; }

        [StringLength(20)]
        public string Status { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? TotalPrice { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? OriginalPrice { get; set; }

        public string? Note { get; set; }

        public string? PaymentMethod { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Discount")]
        public int? DiscountId { get; set; }

        [ForeignKey("Stadium")]
        public int StadiumId { get; set; }

        [ForeignKey("BookingMonthly")]
        public int? MonthlyBookingId { get; set; }
        public virtual MonthlyBooking? MonthlyBooking { get; set; }

        // Navigation properties
        public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
    }
}
