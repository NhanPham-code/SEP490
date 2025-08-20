using System.Globalization;

namespace UserAPI.Helper
{
    public static class DateHelper
    {
        private const string DateFormat = "yyyy-MM-dd";

        public static bool TryParse(string? input, out DateOnly result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                result = default;
                return false;
            }

            return DateOnly.TryParseExact(
                input,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out result
            );
        }

        public static DateOnly Parse(string input)
        {
            return DateOnly.ParseExact(
                input,
                DateFormat,
                CultureInfo.InvariantCulture
            );
        }

        /// <summary>
        /// Format DateOnly về dạng dd/MM/yyyy để hiển thị
        /// </summary>
        public static string FormatDate(DateOnly? date)
        {
            if (date == null) return string.Empty;
            return date.Value.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static string ToString(DateOnly date)
        {
            return date.ToString(DateFormat, CultureInfo.InvariantCulture);
        }
    }
}
