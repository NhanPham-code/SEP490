using System.Collections.Generic;
using System.Threading.Tasks;
using FeedbackAPI.DTOs;

namespace Service.Interfaces
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackResponse>> GetAllAsync(string accessToken);
        Task<FeedbackResponse?> GetByIdAsync(string accessToken, int id);
        Task<FeedbackResponse?> CreateAsync(CreateFeedback dto, string accessToken);
        Task<bool> UpdateAsync(string accessToken, int id, UpdateFeedback dto);
        Task<bool> DeleteAsync(string accessToken, int id);
        Task<(IEnumerable<FeedbackResponse> data, int totalCount)> GetByStadiumIdPagedAsync(int stadiumId, int page, int pageSize);
        Task<IEnumerable<FeedbackResponse>> GetByStadiumIdAsync(int stadiumId);
    }
}