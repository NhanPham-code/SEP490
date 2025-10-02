using System.Collections;
using UserAPI.DTOs;

namespace UserAPI.Service.Interface
{
    public interface IAiService
    {
        Task<AiCccdResponseModel?> ExtractInfoFromFrontCCCDImage(IFormFile frontCCCDImage);

        Task<AiFaceRegisterResponseModel?> RegisterFaceAsync(IEnumerable<IFormFile> faceImages, string email);

        Task<AiFaceLoginResponseModel?> LoginWithFaceAsync(IFormFile faceImage, IEnumerable<UserEmbeddingDTO> userEmbeddingDTOs);
    }
}
