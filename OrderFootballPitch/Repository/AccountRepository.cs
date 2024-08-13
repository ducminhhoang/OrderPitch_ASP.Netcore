using Microsoft.EntityFrameworkCore;
using OrderFootballPitch.Data;
using OrderFootballPitch.Models;

namespace OrderFootballPitch.Repository
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        private readonly PitchOrderDbContext _context;

        public AccountRepository(PitchOrderDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Account> GetByEmailAsync(string email)
        {
            return await _context.Accounts.SingleOrDefaultAsync(a => a.Email == email);
        }

        public async Task<Account> GetAccountByName(string name)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Name.Contains(name));

        }
    }

}
