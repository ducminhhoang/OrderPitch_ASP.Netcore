using TestApiPitchOrder.DTOs;

namespace TestApiPitchOrder.DTOs
{
    public class FootballPitchDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public string Description { get; set; }
        public double PricePerHour { get; set; }
        public bool IsMaintenance { get; set; }
        public int PitchTypeId { get; set; }
        public PitchTypeDTO PitchType {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
