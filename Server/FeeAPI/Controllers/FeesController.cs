using FeeAPI.DTOs;
using FeeAPI.Model;
using FeeAPI.Service.Interface;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeesController : ControllerBase
    {
        private readonly IFeeService _feeService;

        // Inject thêm IBackgroundJobClient để có thể trigger job
        private readonly IBackgroundJobClient _backgroundJobClient;

        public FeesController(IFeeService feeService, IBackgroundJobClient backgroundJobClient)
        {
            _feeService = feeService ?? throw new ArgumentNullException(nameof(feeService));
            _backgroundJobClient = backgroundJobClient ?? throw new ArgumentNullException(nameof(backgroundJobClient));
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllFees()
        {
            var fees = await _feeService.GetAllFeesAsync();
            return Ok(fees);
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetFeeById(int id)
        {
            var fee = await _feeService.GetFeeByIdAsync(id);
            if (fee == null)
            {
                return NotFound();
            }
            return Ok(fee);
        }

        [HttpGet("stadium/{stadiumId}")]
        //[Authorize(Roles = "Admin,StadiumManager")]
        public async Task<IActionResult> GetFeesByStadiumId(int stadiumId)
        {
            var fees = await _feeService.GetFeesByStadiumIdAsync(stadiumId);
            return Ok(fees);
        }

        [HttpGet("owner/{ownerId}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetFeesByOwnerId(int ownerId)
        {
            var fees = await _feeService.GetFeesByOwnerIdAsync(ownerId);
            return Ok(fees);
        }

        [HttpGet("by-month-year")]
        //[Authorize(Roles = "Admin,StadiumManager")]
        public async Task<IActionResult> GetFeesByMonthYear([FromQuery] int month, [FromQuery] int year)
        {
            var fees = await _feeService.GetFeesByMonthYearAsync(month, year);
            return Ok(fees);
        }

        [HttpPut("paid-update/{id}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFeePaid(int id)
        {
            var existingFee = await _feeService.GetFeeByIdAsync(id);
            if (existingFee == null)
            {
                return NotFound();
            }

            existingFee.IsPaid = true;
            existingFee.PaidDate = DateTime.UtcNow;

            var updatedFee = await _feeService.UpdateFeeAsync(id, existingFee);
            if (updatedFee == null)
            {
                return NotFound();
            }

            return Ok(updatedFee);
        }

        [HttpPut("bill-update")]
        public async Task<IActionResult> UploadBillImage([FromForm] UploadBillImageDTO uploadBillImageDTO)
        {
            var updatedFee = await _feeService.UploadBillImage(uploadBillImageDTO);
            if (updatedFee == null)
            {
                return NotFound();
            }
            return Ok(updatedFee);
        }

        [HttpPost("trigger-fee-calculation")]
        //[Authorize(Roles = "Admin")] // Chỉ Admin được phép
        public IActionResult TriggerFeeCalculation([FromQuery] int year, [FromQuery] int month)
        {
            if (year < 2020 || month < 1 || month > 12)
            {
                return BadRequest("Năm hoặc tháng không hợp lệ.");
            }

            // Enqueue một công việc chạy nền ngay lập tức
            // Thay vì gọi trực tiếp service, chúng ta đưa nó vào Hangfire
            // để không block request và có thể theo dõi trong dashboard.
            var jobId = _backgroundJobClient.Enqueue<IFeeCalculationService>(
                service => service.GenerateFeesAsync(year, month));

            return Ok(new { Message = $"Đã yêu cầu tính phí cho tháng {month}/{year}. Job ID: {jobId}. Theo dõi tại /hangfire." });
        }
    }
}
