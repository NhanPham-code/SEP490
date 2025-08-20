using StadiumAPI.DTOs;
using StadiumAPI.Models;

namespace StadiumAPI.Service.Interface
{
    public interface ICourtRelationService
    {
        Task<IEnumerable<ReadCourtRelationDTO>> GetAllCourtRelationByParentId(int parentId);
        Task<IEnumerable<ReadCourtRelationDTO>> CreateCourtRelation(List<CreateCourtRelationDTO> courtRelation);
        Task<IEnumerable<ReadCourtRelationDTO>> UpdataCourtRelation(List<UpdateCourtRelationDTO> courtRelation);
        Task<bool> DeleteCourtRelationByParentId(int parentId);
    }
}
