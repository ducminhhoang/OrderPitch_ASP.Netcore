using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Accounts
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(10)]
    public string Phone { get; set; }

    [Required]
    [MaxLength(50)]
    public string Email { get; set; }

    [MaxLength(264)]
    public string Password { get; set; }

    [MaxLength(255)]
    public string Address { get; set; }

    [Required]
    [DefaultValue("2")]
    [MaxLength(255)]
    public string AccountType { get; set; }

    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime Created_at { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? Update_at { get; set; }
}
