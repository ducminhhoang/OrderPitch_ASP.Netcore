using TestApiPitchOrder.DTOs;
using TestApiPitchOrder.Models;

namespace TestApiPitchOrder.Services
{
    public interface IFootballPitchService
    {
        Task<IEnumerable<FootballPitch>> GetAllPitchesAsync();
        Task<FootballPitch> GetPitchByIdAsync(int id);
        Task<FootballPitch> CreatePitchAsync(FootballPitchDTO pitchDto);
        Task<FootballPitch> UpdatePitchAsync(int id, FootballPitchDTO pitchDto);
        Task UpdatePitch(FootballPitch footballPitch);
        Task<bool> DeletePitchAsync(int id);
        Task<IEnumerable<FootballPitch>> SearchPitchesByNameAsync(string name);
        Task<PaggingDTO<PitchShort>> GetPitchPagging(int pageNumber, int pageSize);
    }
}
