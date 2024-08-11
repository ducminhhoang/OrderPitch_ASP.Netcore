using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestApiPitchOrder.Models
{
    public class FootballPitch
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public TimeSpan TimeStart { get; set; }

        [Required]
        public TimeSpan TimeEnd { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        [Required]
        [Range(10, int.MaxValue)]
        public double PricePerHour { get; set; }

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
