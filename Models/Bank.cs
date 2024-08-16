using System.ComponentModel.DataAnnotations;

namespace TestApiPitchOrder.Models
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "No special characters allowed")]
        public string Name { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "No special characters allowed")]
        public string BankNumber { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Image { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
