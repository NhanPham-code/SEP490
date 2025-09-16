using UserAPI.DTOs;

namespace UserAPI.Service.Interface
{
    public interface IAiService
    {
        Task<AiResponseModel?> ExtractInfoFromFrontCCCDImage(IFormFile frontCCCDImage);
    }
}
