using System.ComponentModel.DataAnnotations;

namespace UserAPI.Validator
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class AllowEmptyPhoneAttribute : ValidationAttribute
    {
        // Sử dụng một instance của PhoneAttribute gốc để tái sử dụng logic của nó
        private readonly PhoneAttribute _internalPhoneAttribute = new PhoneAttribute();

        public override bool IsValid(object? value)
        {
            // Nếu giá trị là null hoặc chuỗi rỗng, coi như hợp lệ
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return true;
            }

            // Nếu có giá trị, sử dụng logic của [Phone] gốc để kiểm tra
            return _internalPhoneAttribute.IsValid(value);
        }
    }
}
