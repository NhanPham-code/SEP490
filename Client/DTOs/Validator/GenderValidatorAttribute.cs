using System.ComponentModel.DataAnnotations;

namespace DTOs.Validator
{
    public class GenderValidatorAttribute : ValidationAttribute
    {
        private readonly string[] _allowedValues = { "Male", "Female", "Other", "Nam", "Nữ", "Khác" };

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success; // Cho phép null nếu bạn muốn optional

            string? gender = value.ToString();

            if (string.IsNullOrWhiteSpace(gender))
            {
                return new ValidationResult("Gender is required.");
            }

            if (!_allowedValues.Contains(gender, StringComparer.OrdinalIgnoreCase))
            {
                return new ValidationResult(
                    $"Gender must be one of the following values: {string.Join(", ", _allowedValues)}."
                );
            }

            return ValidationResult.Success;
        }
    }
}
