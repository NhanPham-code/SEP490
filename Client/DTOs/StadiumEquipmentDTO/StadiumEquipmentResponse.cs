using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.StadiumEquipmentDTO
{
    public class StadiumEquipmentResponse
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int QuantityTotal { get; set; }
        public int QuantityAvailable { get; set; }
        public string? Status { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
