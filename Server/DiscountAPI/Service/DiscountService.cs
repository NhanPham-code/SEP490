using AutoMapper;
using AutoMapper.QueryableExtensions;
using DiscountAPI.DTO;
using DiscountAPI.Respository.Interface;
using DiscountAPI.Service.Interface;
using Models;

namespace DiscountAPI.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _repository;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IQueryable<ReadDiscountDTO> GetAll()
        {
            return _repository.GetAll()
                              .ProjectTo<ReadDiscountDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<ReadDiscountDTO?> GetByIdAsync(int id)
        {
            var discount = await _repository.GetByIdAsync(id);
            return _mapper.Map<ReadDiscountDTO>(discount);
        }

        public async Task<ReadDiscountDTO?> GetByCodeAsync(string code)
        {
            var discount = await _repository.GetByCodeAsync(code);
            return _mapper.Map<ReadDiscountDTO>(discount);
        }

        public IQueryable<ReadDiscountDTO> GetByStadiumId(int stadiumId)
        {
            return _repository.GetByStadiumId(stadiumId)
                              .ProjectTo<ReadDiscountDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<ReadDiscountDTO> CreateAsync(CreateDiscountDTO dto)
        {


            var entity = _mapper.Map<Discount>(dto);
            var created = await _repository.CreateAsync(entity);
            return _mapper.Map<ReadDiscountDTO>(created);
        }

        public async Task UpdateAsync(UpdateDiscountDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                throw new KeyNotFoundException($"Discount with ID {dto.Id} not found.");


            // Map các trường đơn lẻ
            _mapper.Map(dto, entity);

            // Log các stadiumIds
            Console.WriteLine("DTO stadiumIds: " + string.Join(", ", dto.StadiumIds ?? new List<int>()));

            // Gọi repository update, truyền riêng stadiumIds
            await _repository.UpdateAsync(entity, dto.StadiumIds ?? new List<int>());
        }

        public async Task DeleteAsync(int id)
        {
            var discount = await _repository.GetByIdAsync(id);
            if (discount == null)
                throw new KeyNotFoundException($"Discount with ID {id} not found.");
            await _repository.DeleteAsync(id);
        }
        public async Task ScanAndDeactivateExpiredDiscountsAsync()
        {
            Console.WriteLine($"[Hangfire] Bắt đầu quét Discount hết hạn lúc {DateTime.UtcNow}...");


            var expiredDiscounts = await _repository.GetExpiredActiveDiscountsAsync();

            if (!expiredDiscounts.Any())
            {
                Console.WriteLine("[Hangfire] Không có Discount nào cần khóa.");
                return;
            }

            foreach (var discount in expiredDiscounts)
            {
                discount.IsActive = false;
            }

            await _repository.SaveChangesAsync();

            Console.WriteLine($"[Hangfire] Đã khóa thành công {expiredDiscounts.Count()} Discount.");
        }
    }
}