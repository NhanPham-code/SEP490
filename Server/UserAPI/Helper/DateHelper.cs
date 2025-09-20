using System.Globalization;

namespace UserAPI.Helper
{
    public static class DateHelper
    {
        // Giữ nguyên định dạng mặc định cho các chức năng cũ
        private const string DefaultDateFormat = "yyyy-MM-dd";

        // === HÀM CŨ (Không thay đổi) ===
        // Hàm này sẽ tiếp tục hoạt động cho các chức năng cũ của bạn
        public static DateOnly Parse(string input)
        {
            return Parse(input, DefaultDateFormat); // Gọi phiên bản mới với định dạng mặc định
        }

        // === HÀM MỚI (Nạp chồng) ===
        // Phiên bản mới này linh hoạt hơn, cho phép truyền vào định dạng bất kỳ
        public static DateOnly Parse(string input, string format)
        {
            if (DateOnly.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            {
                return result;
            }
            // Ném ra lỗi với thông báo cụ thể để dễ dàng gỡ lỗi
            throw new FormatException($"Chuỗi '{input}' không hợp lệ. Định dạng ngày tháng mong đợi là '{format}'.");
        }

        // === CÁC HÀM KHÁC (Cập nhật để nhất quán) ===

        public static bool TryParse(string? input, out DateOnly result)
        {
            // Mặc định vẫn thử parse theo định dạng cũ
            return TryParse(input, DefaultDateFormat, out result);
        }

        // Phiên bản TryParse nạp chồng
        public static bool TryParse(string? input, string format, out DateOnly result)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                result = default;
                return false;
            }

            return DateOnly.TryParseExact(
                input,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out result
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
            return date.ToString(DefaultDateFormat, CultureInfo.InvariantCulture);
        }
    }
}