namespace FeeAPI.Model
{
    public class Fee
    {
        public int Id { get; set; }

        public int StadiumId { get; set; }

        public int OwnerId { get; set; } // lấy từ Stadium.CreatedBy

        public int Month { get; set; }

        public int Year { get; set; }

        public decimal TotalRevenue { get; set; }

        public decimal FeeAmount { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsPaid { get; set; }

        public DateTime? PaidDate { get; set; }

        public string? Notes { get; set; }

        public string? BillUrl { get; set; }
    }
}
