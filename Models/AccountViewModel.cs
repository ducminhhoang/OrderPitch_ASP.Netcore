using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PitchOrderMVC.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        [DisplayName("Account Name")]
        public string Name { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(255, MinimumLength = 5)]
        public string Address { get; set; }
        [StringLength(255, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        public int AccountTypeId { get; set; } = 2;
    }
}
