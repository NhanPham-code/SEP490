using Microsoft.EntityFrameworkCore;
using StadiumAPI.Data;
using StadiumAPI.DTOs;
using StadiumAPI.Models;
using StadiumAPI.Repositories.Interface;

namespace StadiumAPI.Repositories
{
    public class CourtRelationRepositories : ICourtRelationRepositories
    {
        private readonly StadiumDbContext _context;
        public CourtRelationRepositories(StadiumDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourtRelations>> CreateCourtRelation(List<CourtRelations> courtRelation)
        {
            await _context.AddRangeAsync(courtRelation);
            await _context.SaveChangesAsync();

            return courtRelation.AsEnumerable<CourtRelations>();

        }

        public async Task<bool> DeleteCourtRelationByParentId(int parentId)
        {
            var deleteCourtRelation = GetAllCourtRelationByParentId(parentId);
            for (int i = 0; i < deleteCourtRelation.Result.Count(); i++)
            {
                _context.Remove(deleteCourtRelation.Result.ElementAt(i));
            }
            return await _context.SaveChangesAsync().ContinueWith(t => true);
        }

        public async Task<IEnumerable<CourtRelations>> GetAllCourtRelationByParentId(int parentId)
        {
            return await _context.CourtRelations.Where(c => c.ParentCourtId == parentId).ToListAsync();
        }

        public async Task<IEnumerable<CourtRelations>> UpdataCourtRelation(List<CourtRelations> courtRelation)
        {
            _context.ChangeTracker.Clear();
            _context.UpdateRange(courtRelation);
            await _context.SaveChangesAsync();

            var parentCourtId = courtRelation.FirstOrDefault()?.ParentCourtId;

            return await GetAllCourtRelationByParentId(parentCourtId.Value);


        }
    }
}
