using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.FavoriteStadiumDTO
{
    public class ReadFavoriteDTO
    {
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        public int StadiumId { get; set; }
    }
}
