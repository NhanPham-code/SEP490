using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class DiscountStadium
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Discount")]
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }

        // Ở service stadium sẽ quản lý Stadium, ở đây chỉ cần lưu StadiumId
        public int StadiumId { get; set; }
    }
}
