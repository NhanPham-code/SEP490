using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.StadiumDTO
{
    public class ReadStadiumVideoDTO
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public string VideoUrl { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}