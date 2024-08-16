using TestApiPitchOrder.DTOs;
using TestApiPitchOrder.Models;

namespace TestApiPitchOrder.Repository
{
    public interface IFootballPitchRepository
    {
        Task<IEnumerable<FootballPitch>> GetAllPitchesAsync();
        Task<FootballPitch> GetPitchByIdAsync(int id);
        Task<FootballPitch> CreatePitchAsync(FootballPitch pitch);
        Task<FootballPitch> UpdatePitchAsync(FootballPitch pitch);
        Task UpdatePitch(FootballPitch footballPitch);
        Task<bool> DeletePitchAsync(int id);
        Task<IEnumerable<FootballPitch>> SearchPitchesByNameAsync(string name);
        Task<PaggingDTO<PitchShort>> GetPitchPagging(int pageNumber, int pageSize);
    }
}
