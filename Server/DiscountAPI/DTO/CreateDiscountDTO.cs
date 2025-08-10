namespace DiscountAPI.DTO
{
    // CreateDiscountDTO
    public class CreateDiscountDTO
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public float PercentValue { get; set; }
        public float MaxDiscountAmount { get; set; }
        public float MinOrderAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CodeType { get; set; }
    }
}
