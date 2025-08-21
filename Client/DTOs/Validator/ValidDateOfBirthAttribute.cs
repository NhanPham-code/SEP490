using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DTOs.Validator
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int MinimumAge { get; }

        public DateOfBirthAttribute(int minimumAge = 18)
        {
            MinimumAge = minimumAge;
            ErrorMessage = $"Date of birth must indicate an age of at least {minimumAge}.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                // cho phép null, nếu muốn bắt buộc thì dùng thêm [Required]
                return ValidationResult.Success;
            }

            string dobString = value.ToString();
            if (!DateOnly.TryParseExact(dobString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dob))
            {
                return new ValidationResult("Date of birth must be in formatyyyy-MM-dd.");
            }

            var today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - dob.Year;

            if (dob.AddYears(age) > today)
            {
                age--;
            }

            if (age < MinimumAge)
            {
                return new ValidationResult($"You must be at least {MinimumAge} years old.");
            }

            return ValidationResult.Success;
        }
    }
}
