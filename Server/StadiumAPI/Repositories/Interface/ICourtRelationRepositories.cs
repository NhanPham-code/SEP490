using StadiumAPI.Models;

namespace StadiumAPI.Repositories.Interface
{
    public interface ICourtRelationRepositories
    {
        Task<IEnumerable<CourtRelations>> GetAllCourtRelationByParentId(int parentId);
        Task<IEnumerable<CourtRelations>> CreateCourtRelation(List<CourtRelations> courtRelation);
        Task<IEnumerable<CourtRelations>> UpdataCourtRelation(List<CourtRelations> courtRelation);
        Task<bool> DeleteCourtRelationByParentId(int parentId);
    }
}
