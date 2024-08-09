using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderFootballPitch.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(255, MinimumLength = 8)]
        public string Password { get; set; }

        [StringLength(255, MinimumLength = 5)]
        public string Address { get; set; }

        [Required]
        public int AccountTypeId { get; set; } = 2;

        [ForeignKey("AccountTypeId")]
        public AccountType AccountType { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Order> Orders { get; set; }
    }
}
