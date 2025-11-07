using System.ComponentModel.DataAnnotations;
using UserAPI.Validator;

namespace UserAPI.DTOs
{
    public class CustomerRegisterRequestDTO
    {
        [Required(ErrorMessage = "Họ và tên không được để trống.")]
        [StringLength(100, ErrorMessage = "Họ và tên không được vượt quá 100 ký tự.")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string Password { get; set; } = null!;

        [StringLength(255, ErrorMessage = "Địa chỉ không được vượt quá 255 ký tự.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [RegularExpression(@"^(0[35789])\d{8}$", ErrorMessage = "Số điện thoại không đúng định dạng Việt Nam.")]
        public string PhoneNumber { get; set; } = null!;

        [GenderValidator]
        public string? Gender { get; set; }

        [DateOfBirth(15)] // bắt buộc >= 15 tuổi đối với khách hàng
        public string? DateOfBirth { get; set; }

        public IFormFile? Avatar { get; set; }

        // thêm 5 ảnh khuông mặt
        public List<IFormFile>? FaceImages { get; set; }
    }
}
