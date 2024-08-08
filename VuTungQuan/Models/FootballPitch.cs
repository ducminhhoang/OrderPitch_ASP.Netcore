using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VuTungQuan.Models
{
    public class FootballPitch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime TimeStart { get; set; }

        [Required]
        public DateTime TimeEnd { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [Required]
        public decimal PricePerHour { get; set; }

        [Required]
        public bool IsMaintenance { get; set; }

        [Required]
        public int PitchTypeId { get; set; }

        [ForeignKey("PitchTypeId")]
        public PitchType PitchType { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<PitchImage> PitchImages { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
