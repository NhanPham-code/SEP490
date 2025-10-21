using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.FeesDTO
{
    public class UploadBillImageDTO
    {
        public int FeeId { get; set; }
        public string? StadiumName { get; set; }
        public IFormFile? BillImage { get; set; }
    }
}
