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

        // Phương thức đã được thêm vào để lấy các mã giảm giá theo ID sân
        public IQueryable<ReadDiscountDTO> GetByStadiumId(int stadiumId)
        {
            // Gọi phương thức từ Repository và ánh xạ kết quả sang DTO
            return _repository.GetByStadiumId(stadiumId)
                              .ProjectTo<ReadDiscountDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<ReadDiscountDTO> CreateAsync(CreateDiscountDTO dto)
        {
            var existingDiscount = await _repository.GetByCodeAsync(dto.Code);
            if (existingDiscount != null)
            {
                throw new InvalidOperationException($"Discount with code '{dto.Code}' already exists.");
            }

            var entity = _mapper.Map<Discount>(dto);
            var created = await _repository.CreateAsync(entity);
            return _mapper.Map<ReadDiscountDTO>(created);
        }

        public async Task UpdateAsync(UpdateDiscountDTO dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Discount with ID {dto.Id} not found.");
            }

            if (!string.Equals(entity.Code, dto.Code, StringComparison.OrdinalIgnoreCase))
            {
                var existingDiscount = await _repository.GetByCodeAsync(dto.Code);
                if (existingDiscount != null && existingDiscount.Id != dto.Id)
                {
                    throw new InvalidOperationException($"Discount with code '{dto.Code}' already exists for another discount.");
                }
            }

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var discount = await _repository.GetByIdAsync(id);
            if (discount == null)
            {
                throw new KeyNotFoundException($"Discount with ID {id} not found.");
            }
            await _repository.DeleteAsync(id);
        }
    }
}