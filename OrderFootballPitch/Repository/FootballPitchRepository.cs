using Microsoft.EntityFrameworkCore;
using OrderFootballPitch.Data;
using OrderFootballPitch.Models;

namespace OrderFootballPitch.Repository
{
    public class FootballPitchRepository : BaseRepository<FootballPitch>, IFootballPitchRepository
    {
        private readonly PitchOrderDbContext _context;

        public FootballPitchRepository(PitchOrderDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FootballPitch>> SearchPitchesByNameAsync(string name)
        {
            return await _context.FootballPitches
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }

    }
}
