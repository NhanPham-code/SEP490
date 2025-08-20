using AutoMapper;
using StadiumAPI.DTOs;
using StadiumAPI.Models;
using StadiumAPI.Repositories.Interface;
using StadiumAPI.Service.Interface;

namespace StadiumAPI.Service
{
    public class CourtRelationService : ICourtRelationService
    {

        private readonly ICourtRelationRepositories _courtRelationRepositories;
        private readonly IMapper _mapper;

        public CourtRelationService(ICourtRelationRepositories courtRelationRepositories, IMapper mapper)
        {
            _courtRelationRepositories = courtRelationRepositories;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReadCourtRelationDTO>> CreateCourtRelation(List<CreateCourtRelationDTO> courtRelation)
        {
            var entities = _mapper.Map<List<CourtRelations>>(courtRelation);

            var created = await _courtRelationRepositories.CreateCourtRelation(entities);

            return _mapper.Map<IEnumerable<ReadCourtRelationDTO>>(created);
        }


        public async Task<bool> DeleteCourtRelationByParentId(int parentId)
        {
            return await _courtRelationRepositories.DeleteCourtRelationByParentId(parentId);
        }

        public async Task<IEnumerable<ReadCourtRelationDTO>> GetAllCourtRelationByParentId(int parentId)
        {
            var courtRelation = await _courtRelationRepositories.GetAllCourtRelationByParentId(parentId);
            return _mapper.Map<IEnumerable<ReadCourtRelationDTO>>(courtRelation);
        }

        public async Task<IEnumerable<ReadCourtRelationDTO>> UpdataCourtRelation(List<UpdateCourtRelationDTO> courtRelation)
        {
            var entities = _mapper.Map<List<CourtRelations>>(courtRelation);

            var created = await _courtRelationRepositories.UpdataCourtRelation(entities);

            return _mapper.Map<IEnumerable<ReadCourtRelationDTO>>(created);
        }
    }
}
