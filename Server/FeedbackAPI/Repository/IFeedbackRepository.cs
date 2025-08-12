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

        IQueryable<Feedback> GetAllAsQueryable();
    }
}
