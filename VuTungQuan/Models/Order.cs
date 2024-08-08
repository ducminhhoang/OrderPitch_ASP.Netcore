using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace VuTungQuan.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "No special characters allowed")]
        public string Name { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Range(0.2, Double.MaxValue)]
        public double Deposit { get; set; }

        [Required]
        public DateTime StartAt { get; set; }

        [Required]
        public DateTime EndAt { get; set; }

        [Required]
        public double Total { get; set; }

        [Required]
        public int Status { get; set; }
        public string Note { get; set; }

        [Required]
        public string BankId { get; set; }
        [Required]
        [ForeignKey("BankId")]
        public Bank bank { get; set; }

        [Required]
        public string DiscountId { get; set; }
        [ForeignKey("DiscountId")]
        public Discount discount { get; set; }

        [Required]
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account account { get; set; }

        [Required]
        public int FootballPitchId { get; set; }

        [ForeignKey("FootballPitchId")]
        public FootballPitch FootballPitch { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
