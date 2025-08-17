using FeedbackAPI.DTOs;

namespace FeedbackAPI.Service
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackResponse>> GetAllAsync();
        Task<FeedbackResponse?> GetByIdAsync(int id);
        Task<FeedbackResponse> CreateAsync(CreateFeedback dto);
        Task<bool> UpdateAsync(int id, UpdateFeedback dto);
        Task<bool> DeleteAsync(int id);

       
    }
}
