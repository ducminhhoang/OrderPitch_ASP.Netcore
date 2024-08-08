using System.ComponentModel.DataAnnotations;
using VuTungQuan.Models;

public class Discount
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 10)]
    public string Code { get; set; }

    [Required]
    [Range(1, 100)]
    public decimal Amount { get; set; }

    [Range(1, Double.MaxValue)]
    public decimal? UsageLimit { get; set; }

    [Required]
    public TimeSpan TimeRemain { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public ICollection<Order> Orders { get; set; }
}