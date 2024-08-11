using Microsoft.EntityFrameworkCore;
using OrderFootballPitch.Data;
using OrderFootballPitch.Models;

namespace OrderFootballPitch.Repository
{
    public class FootballPitchRepository : IFootballPitchRepository
    {
        private readonly PitchOrderDbContext _context;

        public FootballPitchRepository(PitchOrderDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FootballPitch>> GetAllPitchesAsync()
        {
            return await _context.FootballPitches.ToListAsync();
        }

        public async Task<FootballPitch> GetPitchByIdAsync(int id)
        {
            return await _context.FootballPitches.FindAsync(id);
        }

        public async Task<FootballPitch> CreatePitchAsync(FootballPitch pitch)
        {
            _context.FootballPitches.Add(pitch);
            await _context.SaveChangesAsync();
            return pitch;
        }

        public async Task<FootballPitch> UpdatePitchAsync(FootballPitch pitch)
        {
            _context.FootballPitches.Update(pitch);
            await _context.SaveChangesAsync();
            return pitch;
        }

        public async Task<bool> DeletePitchAsync(int id)
        {
            var pitch = await _context.FootballPitches.FindAsync(id);
            if (pitch == null)
                return false;

            _context.FootballPitches.Remove(pitch);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<FootballPitch>> SearchPitchesByNameAsync(string name)
        {
            return await _context.FootballPitches
                .Where(p => p.Name.Contains(name))
                .ToListAsync();
        }

    }
}
