namespace DiscountAPI.DTO
{
    public class UpdateDiscountDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float PercentValue { get; set; }
        public float MaxDiscountAmount { get; set; }
        public float MinOrderAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CodeType { get; set; }
        public bool IsActive { get; set; }
    }
}
