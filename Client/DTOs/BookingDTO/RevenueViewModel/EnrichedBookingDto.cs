namespace DTOs.BookingDTO.RevenueViewModel;

public class EnrichedBookingDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Status { get; set; }
    public DateTime Date { get; set; }
    public decimal? TotalPrice { get; set; }
    public decimal? OriginalPrice { get; set; }
    public string? Note { get; set; }
    public string? PaymentMethod { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int StadiumId { get; set; }
    public int? MonthlyBookingId { get; set; }
    public List<BookingDetailReadDto> BookingDetails { get; set; } = new List<BookingDetailReadDto>();

    // Thêm trường user
    public UserProfileDto User { get; set; }
}