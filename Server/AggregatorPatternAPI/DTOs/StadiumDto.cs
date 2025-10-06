using StadiumAPI.DTOs;

namespace AggregatorPatternAPI.DTOs
{
    public class StadiumDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ReadCourtDTO> Courts { get; set; }
    }
}