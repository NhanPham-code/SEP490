using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.StadiumDTO
{
    public class UpdateStadiumRequest
    {
        public UpdateStadiumDTO Stadium { get; set; }
        public List<CreateStadiumImageDTO> StadiumImage { get; set; } = new List<CreateStadiumImageDTO>();
        public List<CreateStadiumVideoDTO> StadiumVideo { get; set; } = new List<CreateStadiumVideoDTO>();
        public int[] DeletedImageIds { get; set; } = Array.Empty<int>();
        public int[] DeletedVideoIds { get; set; } = Array.Empty<int>();
    }
}