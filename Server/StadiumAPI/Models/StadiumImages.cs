using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StadiumAPI.Models
{
    public class StadiumImages
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Stadium")]
        public int StadiumId { get; set; }

        public string ImageUrl { get; set; }

        public DateTime UploadedAt { get; set; }
        public virtual Stadiums Stadium { get; set; }

    }
}
