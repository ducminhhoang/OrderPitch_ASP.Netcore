using OrderFootballPitch.Models;
using OrderFootballPitch.Repository;

namespace OrderFootballPitch.Services
{
    public class FootballPitchService : BaseService<FootballPitch>, IFootballPitchService
    {
        private readonly IFootballPitchRepository _repository;

        public FootballPitchService(IFootballPitchRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FootballPitch>> SearchPitchesByNameAsync(string name)
        {
            return await _repository.SearchPitchesByNameAsync(name);
        }
    }
}
