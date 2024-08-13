using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrderFootballPitch.DTOs
{
    public class PitchImageDTO
    {
        public int Id { get; set; }
        public int FootballPitchId { get; set; }
        public string Image { get; set; }
    }
}
