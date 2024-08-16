using System.ComponentModel.DataAnnotations;

namespace TestApiPitchOrder.DTOs
{
    public class AccountDTO
    {
        [Required]
        [StringLength(255, MinimumLength = 5)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(255, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
