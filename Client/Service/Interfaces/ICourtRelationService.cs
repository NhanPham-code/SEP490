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
        Task<IEnumerable<ReadCourtRelationDTO>> GetAllCourtRelationByParentId(int parentId);
        Task<IEnumerable<ReadCourtRelationDTO>> GetAllCourtRelationBychildId(int childId);
        Task<IEnumerable<ReadCourtRelationDTO>> CreateCourtRelation(int[] childCourt, int parentCourt);
        Task<IEnumerable<ReadCourtRelationDTO>> UpdateCourtRelation(int[] childCourt, int parentCourt);
        Task<bool> DeleteCourtRelation(int parentId);
    }
}
