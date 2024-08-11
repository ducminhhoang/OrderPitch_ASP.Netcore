using OrderFootballPitch.Models;

namespace OrderFootballPitch.Repository
{
    public interface IFootballPitchRepository
    {
        Task<IEnumerable<FootballPitch>> GetAllPitchesAsync();
        Task<FootballPitch> GetPitchByIdAsync(int id);
        Task<FootballPitch> CreatePitchAsync(FootballPitch pitch);
        Task<FootballPitch> UpdatePitchAsync(FootballPitch pitch);
        Task<bool> DeletePitchAsync(int id);
        Task<IEnumerable<FootballPitch>> SearchPitchesByNameAsync(string name);
    }
}
