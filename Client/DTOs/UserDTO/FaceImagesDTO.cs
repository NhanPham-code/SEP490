using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.UserDTO
{
    public class FaceImagesDTO
    {
        public List<IFormFile>? FaceImages { get; set; }
    }
}
