using AutoMapper;
using StadiumAPI.DTOs;
using StadiumAPI.Repositories.Interface;
using StadiumAPI.Service.Interface;

namespace StadiumAPI.Service
{
    public class StadiumImagesService : IStadiumImagesService
    {
        private readonly IStadiumImagesRepositories _stadiumImagesRepositories;
        private readonly IMapper _mapper;

        public StadiumImagesService(IStadiumImagesRepositories stadiumImagesRepositories, IMapper mapper)
        {
            _stadiumImagesRepositories = stadiumImagesRepositories ?? throw new ArgumentNullException(nameof(stadiumImagesRepositories));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ReadStadiumImageDTO> AddImageAsync(CreateStadiumImageDTO image, string imgUrl)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            var stadiumImage = _mapper.Map<Models.StadiumImages>(image);
            stadiumImage.ImageUrl = imgUrl;

            var savedImage = await _stadiumImagesRepositories.AddImageAsync(stadiumImage);
            return _mapper.Map<ReadStadiumImageDTO>(savedImage);
        }

        public async Task<ReadStadiumImageDTO> UpdateImageAsync(int id, UpdateStadiumImageDTO image, string imageUrl)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            var stadiumImage = _mapper.Map<Models.StadiumImages>(image);
            stadiumImage.Id = id; // Ensure the ID is set for the update
            stadiumImage.ImageUrl = imageUrl; // Assuming UpdateStadiumImageDTO has a property for the image URL
            return await _stadiumImagesRepositories.UpdateImageAsync(id, stadiumImage)
                .ContinueWith(t => _mapper.Map<ReadStadiumImageDTO>(t.Result));
        }

        public Task<bool> DeleteImageAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid image ID.", nameof(id));
            return _stadiumImagesRepositories.DeleteImageAsync(id);
        }

        public Task<IEnumerable<ReadStadiumImageDTO>> GetAllImagesAsync(int stadiumId)
        {
            if (stadiumId <= 0)
                throw new ArgumentException("Invalid stadium ID.", nameof(stadiumId));
            return _stadiumImagesRepositories.GetAllImagesAsync(stadiumId)
                .ContinueWith(t => t.Result.Select(i => _mapper.Map<ReadStadiumImageDTO>(i)));
        }

        public Task<ReadStadiumImageDTO> GetImageByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid image ID.", nameof(id));
            return _stadiumImagesRepositories.GetImageByIdAsync(id)
                .ContinueWith(t => _mapper.Map<ReadStadiumImageDTO>(t.Result));
        }
    }
}