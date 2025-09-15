using DTOs.StadiumDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.FavoriteStadiumDTO
{
    public class FavoriteStadiumViewModel : ReadStadiumDTO
    {
        /// <summary>
        /// Cờ để xác định sân vận động này có phải là yêu thích hay không.
        /// Đối với API trả về danh sách yêu thích, giá trị này sẽ luôn là true.
        /// </summary>
        public bool IsFavorite { get; set; } = true;
    }
}
