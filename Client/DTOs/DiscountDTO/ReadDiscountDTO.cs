namespace DTOs.DiscountDTO
{
    public class ReadDiscountDTO
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public double PercentValue { get; set; }
        public decimal MaxDiscountAmount { get; set; }
        public decimal MinOrderAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CodeType { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } = null!;
        public List<int>? StadiumIds { get; set; } = new();
    }
}
