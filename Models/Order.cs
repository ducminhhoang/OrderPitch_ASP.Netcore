using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VuTungQuan.Models;

namespace TestApiPitchOrder.Models
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
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public double Deposit { get; set; }

        [Required]
        public DateTime StartAt { get; set; }

        [Required]
        public DateTime EndAt { get; set; }

        [Required]
        public double Total { get; set; }

        [Required]
        public StatusOrder Status { get; set; }
        public string? Note { get; set; }

        [Required]
        public int? AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account? Account { get; set; }

        [Required]
        public int? FootballPitchId { get; set; }

        [ForeignKey("FootballPitchId")]
        public FootballPitch? FootballPitch { get; set; }

        public int? DiscountId { get; set; }

        [ForeignKey("DiscountId")]
        public Discount? Discount { get; set; }

        public int? BankId { get; set; }

        [ForeignKey("BankId")]
        public Bank? Bank { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }

    public enum StatusOrder
    {
        Waiting,
        Ordered,
        Canceled,
        Completed
    }
}
