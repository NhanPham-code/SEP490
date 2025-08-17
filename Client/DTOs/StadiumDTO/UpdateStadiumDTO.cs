namespace DTOs.StadiumDTO
{
    public class UpdateStadiumDTO
    {
        public int Id { get; set; } // Stadium ID
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool IsApproved { get; set; }
        public int UpdatedBy { get; set; } // User ID of the updater
    }
}
