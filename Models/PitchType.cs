using System.ComponentModel.DataAnnotations;

namespace TestApiPitchOrder.Models
{
    public class PitchType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<FootballPitch>? FootballPitches { get; set; }
    }
}
