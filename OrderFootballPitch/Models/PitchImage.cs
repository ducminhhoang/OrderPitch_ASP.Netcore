using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFootballPitch.Models
{
    public class PitchImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FootballPitchId { get; set; }

        [ForeignKey("FootballPitchId")]
        public FootballPitch FootballPitch { get; set; }

        [Required]
        [StringLength(5000)]
        public string Image { get; set; }
    }
}
