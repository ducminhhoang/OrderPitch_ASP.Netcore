using System.ComponentModel.DataAnnotations;

namespace OrderFootballPitch.Models
{
    public class AccountType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Account>? Accounts { get; set; }
    }
}
