using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApiPitchOrder.Data;
using TestApiPitchOrder.Models;

namespace TestApiPitchOrder.Repository
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        private readonly PitchOrderDbContext _context;
        public AccountRepository(PitchOrderDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }
        public async Task<Account> GetByEmailAsync(string email)
        {
            return await _context.Accounts.SingleOrDefaultAsync(a => a.Email == email);
        }
        public async Task<Account> GetAccountById(int id)
        {
            return await _context.Accounts.FindAsync(id);
            
        }
        public async Task<Account> GetAccountByName(string name)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Name.Contains(name));
            
        }
        
        public async Task AddAccount(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }


        public async Task Edit(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();

        }
        public async Task Delete(int id)
        {
            var a = await _context.Accounts.FindAsync(id);
            if (a != null)
            {
                _context.Accounts.Remove(a);
                await _context.SaveChangesAsync();
            }
        }
    }
}
