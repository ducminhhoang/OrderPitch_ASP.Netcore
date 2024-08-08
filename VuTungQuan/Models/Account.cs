using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VuTungQuan.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(264)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public int AccountTypeId { get; set; }

        [ForeignKey("AccountTypeId")]
        public AccountType accounttype { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<Order> Orders { get; set; }

    }
}