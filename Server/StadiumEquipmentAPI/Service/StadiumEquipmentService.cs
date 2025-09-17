using AutoMapper;
using StadiumEquipmentAPI.DTOs;
using StadiumEquipmentAPI.Models;
using StadiumEquipmentAPI.Repository;

namespace StadiumEquipmentAPI.Service
{
    public class StadiumEquipmentService : IStadiumEquipmentService
    {
        private readonly IStadiumEquipmentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public StadiumEquipmentService(
            IStadiumEquipmentRepository repository,
            IMapper mapper,
            IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<IEnumerable<StadiumEquipmentResponse>> GetAllEquipmentsAsync()
        {
            var equipments = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StadiumEquipmentResponse>>(equipments);
        }

        public async Task<StadiumEquipmentResponse?> GetEquipmentByIdAsync(int id)
        {
            var equipment = await _repository.GetByIdAsync(id);
            return equipment != null ? _mapper.Map<StadiumEquipmentResponse>(equipment) : null;
        }

        public async Task<IEnumerable<StadiumEquipmentResponse>> GetEquipmentsByStadiumIdAsync(int stadiumId)
        {
            var equipments = await _repository.GetByStadiumIdAsync(stadiumId);
            return _mapper.Map<IEnumerable<StadiumEquipmentResponse>>(equipments);
        }

        public async Task<StadiumEquipmentResponse> CreateEquipmentAsync(CreateStadiumEquipment createDto)
        {
            var equipment = _mapper.Map<StadiumEquipments>(createDto);

            // Xử lý upload ảnh nếu có
            if (createDto.ImageFile != null)
            {
                if (!_fileService.IsValidImageFile(createDto.ImageFile))
                    throw new ArgumentException("Invalid image file");

                equipment.ImagePath = await _fileService.UploadImageAsync(createDto.ImageFile, "stadium-equipments");
            }

            var createdEquipment = await _repository.CreateAsync(equipment);
            return _mapper.Map<StadiumEquipmentResponse>(createdEquipment);
        }

        public async Task<StadiumEquipmentResponse?> UpdateEquipmentAsync(int id, UpdateStadiumEquipment updateDto)
        {
            var existingEquipment = await _repository.GetByIdAsync(id);
            if (existingEquipment == null)
                return null;

            var equipment = _mapper.Map(updateDto, existingEquipment);

            // Xử lý ảnh
            if (updateDto.ImageFile != null)
            {
                if (!_fileService.IsValidImageFile(updateDto.ImageFile))
                    throw new ArgumentException("Invalid image file");

                if (!string.IsNullOrEmpty(existingEquipment.ImagePath))
                {
                    await _fileService.DeleteImageAsync(existingEquipment.ImagePath);
                }

                equipment.ImagePath = await _fileService.UploadImageAsync(updateDto.ImageFile, "stadium-equipments");
            }
            else if (updateDto.KeepCurrentImage)
            {
                equipment.ImagePath = existingEquipment.ImagePath;
            }
            else
            {
                if (!string.IsNullOrEmpty(existingEquipment.ImagePath))
                {
                    await _fileService.DeleteImageAsync(existingEquipment.ImagePath);
                }
                equipment.ImagePath = null;
            }

            var updatedEquipment = await _repository.UpdateAsync(id, equipment);
            return updatedEquipment != null ? _mapper.Map<StadiumEquipmentResponse>(updatedEquipment) : null;
        }

        public async Task<bool> DeleteEquipmentAsync(int id)
        {
            var equipment = await _repository.GetByIdAsync(id);
            if (equipment == null)
                return false;

            if (!string.IsNullOrEmpty(equipment.ImagePath))
            {
                await _fileService.DeleteImageAsync(equipment.ImagePath);
            }

            return await _repository.DeleteAsync(id);
        }
    }
}
