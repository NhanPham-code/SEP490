namespace DTOs.StadiumDTO
{
    public class CreateStadiumDTO
    {
        public string Name { get; set; }
        public string NameUnsigned { get; set; }
        public string Address { get; set; }
        public string AddressUnsigned { get; set; }
        public string Description { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool IsLocked { get; set; } = false;
        public int CreatedBy { get; set; } // User ID of the creator
    }
}