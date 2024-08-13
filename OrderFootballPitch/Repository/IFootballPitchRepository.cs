using OrderFootballPitch.Models;

namespace OrderFootballPitch.Repository
{
    public interface IFootballPitchRepository : IBaseRepository<FootballPitch>
    {
        Task<IEnumerable<FootballPitch>> SearchPitchesByNameAsync(string name);
    }
}
