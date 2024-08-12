using Microsoft.EntityFrameworkCore;
using OrderFootballPitch.Data;

namespace OrderFootballPitch.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly PitchOrderDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(PitchOrderDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }

        public async Task<T> Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int entityId)
        {
            var entity = await GetById(entityId);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}