using AutoMapper;
using FeedbackAPI.DTOs;
using FeedbackAPI.Models;
using FeedbackAPI.Repository;

namespace FeedbackAPI.Service
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repository;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeedbackResponse>> GetAllAsync()
        {
            var feedbacks = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks);
        }

        public async Task<FeedbackResponse?> GetByIdAsync(int id)
        {
            var feedback = await _repository.GetByIdAsync(id);
            return feedback == null ? null : _mapper.Map<FeedbackResponse>(feedback);
        }

        public async Task<FeedbackResponse> CreateAsync(CreateFeedback dto)
        {
            var feedback = _mapper.Map<Feedback>(dto);
            await _repository.AddAsync(feedback);
            await _repository.SaveChangesAsync();
            return _mapper.Map<FeedbackResponse>(feedback);
        }

        public async Task<bool> UpdateAsync(int id, UpdateFeedback dto)
        {
            var feedback = await _repository.GetByIdAsync(id);
            if (feedback == null) return false;

            _mapper.Map(dto, feedback);
            await _repository.UpdateAsync(feedback);
            await _repository.SaveChangesAsync();
            return true;
        }
        public IQueryable<FeedbackResponse> GetAllAsQueryable()
        {
            // Lấy IQueryable từ repository
            var query = _repository.GetAllAsQueryable(); // repository cần thêm hàm này
            return _mapper.ProjectTo<FeedbackResponse>(query);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var feedback = await _repository.GetByIdAsync(id);
            if (feedback == null) return false;

            await _repository.DeleteAsync(feedback);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
