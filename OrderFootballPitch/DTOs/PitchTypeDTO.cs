namespace OrderFootballPitch.DTOs
{
    public class PitchTypeDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
