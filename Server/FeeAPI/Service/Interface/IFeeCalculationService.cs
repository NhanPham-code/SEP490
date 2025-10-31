namespace FeeAPI.Service.Interface
{
    public interface IFeeCalculationService
    {
        /// <summary>
        /// Chạy quy trình tính toán và tạo phí cho một tháng/năm cụ thể.
        /// </summary>
        /// <param name="year">Năm cần tính phí.</param>
        /// <param name="month">Tháng cần tính phí.</param>
        Task GenerateFeesAsync(int year, int month);

        /// <summary>
        /// Chạy quy trình tính toán và tạo phí cho tháng trước đó.
        /// Đây là hàm sẽ được gọi bởi background job định kỳ.
        /// </summary>
        Task GenerateFeesForPreviousMonthAsync();
    }
}
