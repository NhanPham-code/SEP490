using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.StadiumDTO
{
    public class CourtsRelationRe7
    {
    
        public int[] childCourtIds { get; set; } // ví dụ: sân 5A
        public int parentCourtId { get; set; } // ví dụ: sân 7
        
    }
}
