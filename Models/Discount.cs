using System.ComponentModel.DataAnnotations;

namespace TestApiPitchOrder.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 10)]
        public string Code { get; set; }

        [Required]
        [Range(1, 100)]
        public int Amount { get; set; }

        [Range(1, double.MaxValue)]
        public double UsageLimit { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
