using System.ComponentModel.DataAnnotations;

namespace TestApiPitchOrder.DTOs
{
    public class PitchShort
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int quanlity { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMaintenance { get; set; }
        public string description { get; set; }
    }
}
