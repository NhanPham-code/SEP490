using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.UserDTO
{
    public class UserSearchRequestDTO
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; }
        public string? Month { get; set; } // Format "YYYY-MM"
        public string? Status { get; set; }
        public string? Role { get; set; }
    }
}
