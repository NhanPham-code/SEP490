using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace UserAPI.Validator
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int MinimumAge { get; }

        public DateOfBirthAttribute(int minimumAge = 15)
        {
            MinimumAge = minimumAge;
            ErrorMessage = $"Date of birth must indicate an age of at least {minimumAge}.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string dateString && !string.IsNullOrEmpty(dateString))
            {
                if (DateTime.TryParse(dateString, out DateTime dateOfBirth))
                {
                    // Kiểm tra không được sinh trước năm 1900
                    if (dateOfBirth.Year < 1900)
                    {
                        return new ValidationResult("Năm sinh không hợp lệ.");
                    }

                    // Kiểm tra tuổi tối thiểu (logic cũ của bạn)
                    if (dateOfBirth > DateTime.Today.AddYears(MinimumAge))
                    {
                        return new ValidationResult($"Bạn phải đủ {MinimumAge} tuổi.");
                    }
                }
                else
                {
                    return new ValidationResult("Định dạng ngày sinh không hợp lệ.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
