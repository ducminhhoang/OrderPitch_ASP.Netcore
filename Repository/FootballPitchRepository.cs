using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestApiPitchOrder.Data;
using TestApiPitchOrder.DTOs;
using TestApiPitchOrder.Models;

namespace TestApiPitchOrder.Repository
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
        public async Task UpdatePitch(FootballPitch footballPitch)
        {
            _context.FootballPitches.Update(footballPitch);
            await _context.SaveChangesAsync();

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

        public async Task<PaggingDTO<PitchShort>> GetPitchPagging(int pageNumber, int pageSize)
        {
            var query = _context.FootballPitches.AsQueryable();
            var totalItems = await query.CountAsync();
            var p = await query
                .Include(p => p.PitchImages)
                .Include(p => p.PitchType)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var pitchDtos = p.Select(p => new PitchShort
            {
                Name = p.Name,
                Price = p.PricePerHour,
                ImageUrl = p.PitchImages.Select(pi => pi.Image).FirstOrDefault(),
                IsMaintenance = p.IsMaintenance,
                description = p.Description,
                quanlity = p.PitchType.Quantity,
                TimeStart = p.TimeStart,
                TimeEnd = p.TimeEnd
            }).ToList();
            return new PaggingDTO<PitchShort>
            {
                Items = pitchDtos,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
    }
}
