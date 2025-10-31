using FeeAPI.DTOs;
using FeeAPI.Model;
using FeeAPI.Repository.Interface;
using FeeAPI.Service.Interface;

namespace FeeAPI.Service
{
    public class FeeService : IFeeService
    {
        private readonly IFeeRepository _feeRepository;

        public FeeService(IFeeRepository feeRepository)
        {
            _feeRepository = feeRepository ?? throw new ArgumentNullException(nameof(feeRepository));
        }

        public async Task<Fee> CreateFeeAsync(Fee fee)
        {
            return await _feeRepository.CreateFeeAsync(fee);
        }

        public async Task<bool> DeleteFeeAsync(int id)
        {
            return await _feeRepository.DeleteFeeAsync(id);
        }

        public async Task<List<Fee>> GetAllFeesAsync()
        {
            return await _feeRepository.GetAllFeesAsync();
        }

        public async Task<Fee?> GetFeeByIdAsync(int id)
        {
            return await _feeRepository.GetFeeByIdAsync(id);
        }

        public async Task<List<Fee>> GetFeesByMonthYearAsync(int month, int year)
        {
            return await _feeRepository.GetFeesByMonthYearAsync(month, year);
        }

        public async Task<List<Fee>> GetFeesByOwnerIdAsync(int ownerId)
        {
            return await _feeRepository.GetFeesByOwnerIdAsync(ownerId);
        }

        public async Task<List<Fee>> GetFeesByStadiumIdAsync(int stadiumId)
        {
            return await _feeRepository.GetFeesByStadiumIdAsync(stadiumId);
        }

        public async Task<Fee?> UpdateFeeAsync(int id, Fee fee)
        {
            return await _feeRepository.UpdateFeeAsync(id, fee);
        }

        public async Task<Fee?> UploadBillImage(UploadBillImageDTO uploadBillImageDTO)
        {
            var existingFee = await _feeRepository.GetFeeByIdAsync(uploadBillImageDTO.FeeId);
            if (existingFee == null || uploadBillImageDTO.BillImage == null)
            {
                return null;
            }

            // SỬA LỖI: Thêm "wwwroot" vào đường dẫn, giống hệt như logic avatar
            var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "bills");
            if (!Directory.Exists(uploadsDir))
            {
                Directory.CreateDirectory(uploadsDir);
            }

            // Nếu hóa đơn cũ tồn tại, có thể xóa đi để tránh rác (tùy chọn)
            if (!string.IsNullOrEmpty(existingFee.BillUrl))
            {
                string oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingFee.BillUrl.TrimStart('/'));
                if (File.Exists(oldFilePath))
                {
                    try
                    {
                        File.Delete(oldFilePath);
                    }
                    catch (Exception ex)
                    {
                        // Ghi log lỗi nếu không xóa được file cũ, nhưng không dừng quy trình
                        Console.WriteLine($"Lỗi khi xóa file hóa đơn cũ: {ex.Message}");
                    }
                }
            }


            // Tạo tên file an toàn
            var safeStadiumName = string.Concat(uploadBillImageDTO.StadiumName.Replace(" ", "_").Split(Path.GetInvalidFileNameChars()));
            var fileExtension = Path.GetExtension(uploadBillImageDTO.BillImage.FileName);
            var fileName = $"{safeStadiumName}_{DateTime.UtcNow:yyyyMMddHHmmss}{fileExtension}";
            var filePath = Path.Combine(uploadsDir, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await uploadBillImageDTO.BillImage.CopyToAsync(stream);
            }

            // Cập nhật đường dẫn ảnh có thể truy cập qua URL
            existingFee.BillUrl = $"/uploads/bills/{fileName}";

            return await _feeRepository.UpdateFeeAsync(existingFee.Id, existingFee);
        }

        public IQueryable<Fee> QueryFees()
        {
            return _feeRepository.GetFeesAsQueryable();
        }
    }
}
