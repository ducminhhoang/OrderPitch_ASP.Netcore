using OrderFootballPitch.DTOs;
using OrderFootballPitch.Models;

namespace OrderFootballPitch.Services
{
    public interface IFootballPitchService
    {
        Task<IEnumerable<FootballPitch>> GetAllPitchesAsync();
        Task<FootballPitch> GetPitchByIdAsync(int id);
        Task<FootballPitch> CreatePitchAsync(FootballPitchDTO pitchDto);
        Task<FootballPitch> UpdatePitchAsync(int id, FootballPitchDTO pitchDto);
        Task<bool> DeletePitchAsync(int id);
        Task<IEnumerable<FootballPitch>> SearchPitchesByNameAsync(string name);
    }
}
