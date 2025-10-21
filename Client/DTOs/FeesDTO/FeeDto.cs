using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.FeesDTO
{
    public class FeeDto
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public int OwnerId { get; set; }
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
