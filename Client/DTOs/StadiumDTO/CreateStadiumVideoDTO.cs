using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.StadiumDTO
{
    public class CreateStadiumVideoDTO
    {
        public int StadiumId { get; set; }
        public IFormFile VideoUrl { get; set; }
    }
}