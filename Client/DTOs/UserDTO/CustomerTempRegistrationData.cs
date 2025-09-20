using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.UserDTO
{
    public class CustomerTempRegistrationData
    {
        public CustomerRegisterRequestDTO RegisterData { get; set; }
        public string VerificationCode { get; set; }
        public DateTime VerificationCodeTimestamp { get; set; }
    }
}
