using OrderFootballPitch.Models;

namespace OrderFootballPitch.Services
{
    public interface IFootballPitchService : IBaseService<FootballPitch>
    {
        Task<IEnumerable<FootballPitch>> SearchPitchesByNameAsync(string name);
    }
}