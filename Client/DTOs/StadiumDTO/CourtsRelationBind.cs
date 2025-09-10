using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.StadiumDTO
{
    public class CourtsRelationBind
    {
        public int courtParentId { get; set; } // ví dụ: sân 7
        public int[] courtChildId { get; set; } // ví dụ: sân 5A, 5B, 5C
        public CourtsRelationRe7[] court7Relations { get; set; }
    }
}
