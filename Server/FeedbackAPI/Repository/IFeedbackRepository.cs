using FeedbackAPI.DTOs;
using FeedbackAPI.Models;

namespace FeedbackAPI.Repository
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllAsync();
        Task<Feedback?> GetByIdAsync(int id);
        Task AddAsync(Feedback feedback);
        Task UpdateAsync(Feedback feedback);
        Task DeleteAsync(Feedback feedback);
        Task SaveChangesAsync();

        Task<IEnumerable<Feedback>> GetByStadiumIdAsync(int stadiumId);


        IQueryable<Feedback> GetAllAsQueryable();
    }
}
