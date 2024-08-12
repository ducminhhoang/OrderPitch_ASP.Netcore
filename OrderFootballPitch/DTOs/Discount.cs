using OrderFootballPitch.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderFootballPitch.DTOs
{
    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public double UsageLimit { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
