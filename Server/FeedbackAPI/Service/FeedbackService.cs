using AutoMapper;
using FeedbackAPI.DTOs;
using FeedbackAPI.Models;
using FeedbackAPI.Repository;
using Microsoft.AspNetCore.Hosting;
using System.IO;

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
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var feedback = _mapper.Map<Feedback>(dto);

            if (dto.Image != null && dto.Image.Length > 0)
            {
                // Lấy folder wwwroot gốc của project
                var webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var uploadsFolder = Path.Combine(webRoot, "uploads", "feedbacks");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                var fileExtension = Path.GetExtension(dto.Image.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(fileExtension))
                    throw new ArgumentException($"File extension {fileExtension} is not allowed");

                var fileName = $"{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(stream);
                }

                feedback.ImagePath = $"/uploads/feedbacks/{fileName}";
            }

            await _repository.AddAsync(feedback);
            await _repository.SaveChangesAsync();

            return _mapper.Map<FeedbackResponse>(feedback);
        }

        public async Task<bool> UpdateAsync(int id, UpdateFeedback dto)
        {
            var feedback = await _repository.GetByIdAsync(id);
            if (feedback == null) return false;

            _mapper.Map(dto, feedback);

            if (dto.Image != null && dto.Image.Length > 0)
            {
                var webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var uploadsFolder = Path.Combine(webRoot, "uploads", "feedbacks");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                // Xóa file cũ nếu có
                if (!string.IsNullOrEmpty(feedback.ImagePath))
                {
                    var oldFilePath = Path.Combine(webRoot, feedback.ImagePath.TrimStart('/').Replace("/", "\\"));
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                var fileExtension = Path.GetExtension(dto.Image.FileName).ToLowerInvariant();

                if (!allowedExtensions.Contains(fileExtension))
                    throw new ArgumentException($"File extension {fileExtension} is not allowed");

                var fileName = $"{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(stream);
                }

                feedback.ImagePath = $"/uploads/feedbacks/{fileName}";
            }

            await _repository.UpdateAsync(feedback);
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var feedback = await _repository.GetByIdAsync(id);
            if (feedback == null) return false;

            if (!string.IsNullOrEmpty(feedback.ImagePath))
            {
                var webRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                var filePath = Path.Combine(webRoot, feedback.ImagePath.TrimStart('/').Replace("/", "\\"));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            await _repository.DeleteAsync(feedback);
            await _repository.SaveChangesAsync();
            return true;
        }

        public IQueryable<FeedbackResponse> GetAllAsQueryable()
        {
            var query = _repository.GetAllAsQueryable();
            return _mapper.ProjectTo<FeedbackResponse>(query);
        }

        public async Task<IEnumerable<FeedbackResponse>> GetByStadiumIdAsync(int stadiumId)
        {
            var feedbacks = await _repository.GetByStadiumIdAsync(stadiumId);
            return _mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks);
        }
    }
}
