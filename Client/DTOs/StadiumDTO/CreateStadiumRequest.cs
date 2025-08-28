using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.StadiumDTO
{
    public class CreateStadiumRequest
    {
        public CreateStadiumDTO Stadium { get; set; }
        public List<CreateStadiumImageDTO> StadiumImage { get; set; }
    }
}