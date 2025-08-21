using StadiumAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICourtRelationService
    {
        Task<ReadCourtRelationDTO> GetAllCourtRelationByParentId(int parentId);
        Task<ReadCourtRelationDTO> GetAllCourtRelationBychildId(int childId);
        Task<ReadCourtRelationDTO> CreateCourtRelation(int[] childCourt, int parentCourt);
        Task<ReadCourtRelationDTO> UpdateCourtRelation(int[] childCourt, int parentCourt);
        Task<bool> DeleteCourtRelation(int parentId);
    }
}
