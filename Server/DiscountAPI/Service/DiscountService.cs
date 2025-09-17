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
                throw new KeyNotFoundException($"Discount with ID {dto.Id} not found.");

            if (!string.Equals(entity.Code, dto.Code, StringComparison.OrdinalIgnoreCase))
            {
                var existingDiscount = await _repository.GetByCodeAsync(dto.Code);
                if (existingDiscount != null && existingDiscount.Id != dto.Id)
                {
                    throw new InvalidOperationException($"Discount with code '{dto.Code}' already exists for another discount.");
                }
            }

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
    }
}