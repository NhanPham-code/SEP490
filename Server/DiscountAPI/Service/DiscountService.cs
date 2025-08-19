using AutoMapper;
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

        public async Task<IEnumerable<ReadDiscountDTO>> GetAllAsync()
        {
            var discounts = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadDiscountDTO>>(discounts);
        }

        public async Task<ReadDiscountDTO> GetByIdAsync(int id)
        {
            var discount = await _repository.GetByIdAsync(id);
            return _mapper.Map<ReadDiscountDTO>(discount);
        }

        public async Task<ReadDiscountDTO> GetByCodeAsync(string code)
        {
            var discount = await _repository.GetByCodeAsync(code);
            return _mapper.Map<ReadDiscountDTO>(discount);
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
            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }

}
