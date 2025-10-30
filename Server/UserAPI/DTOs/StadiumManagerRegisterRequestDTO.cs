using System.ComponentModel.DataAnnotations;
using UserAPI.Validator;

namespace UserAPI.DTOs
{
    public class StadiumManagerRegisterRequestDTO
    {

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [RegularExpression(@"^(0[35789])\d{8}$", ErrorMessage = "Số điện thoại không đúng định dạng Việt Nam.")]
        public string? PhoneNumber { get; set; }

        public IFormFile? Avatar { get; set; }

        public IFormFile? FrontCCCDImage { get; set; }

        public IFormFile? RearCCCDImage { get; set; }
    }
}
