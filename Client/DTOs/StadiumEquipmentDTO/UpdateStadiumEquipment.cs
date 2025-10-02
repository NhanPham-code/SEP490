using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.StadiumEquipmentDTO
{
    public class UpdateStadiumEquipment
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int QuantityTotal { get; set; }
        public int QuantityAvailable { get; set; }
        public string? Status { get; set; }
        public bool KeepCurrentImage { get; set; }
        public IFormFile? ImageFile { get; set; }  // ✅ đổi thành IFormFile
    }
}
