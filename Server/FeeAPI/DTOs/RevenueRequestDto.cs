using System.ComponentModel.DataAnnotations;

namespace FeeAPI.DTOs
{
    public class RevenueRequestDto
    {
        [Required]
        [MinLength(1)]
        public List<int> StadiumIds { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }
    }
}
