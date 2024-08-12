using Microsoft.EntityFrameworkCore;
using OrderFootballPitch.Data;

using OrderFootballPitch.Models;
public interface IAccountRepository
{
    Task<Account> GetByEmailAsync(string email);
    Task CreateAsync(Account account);
}


public class AccountRepository : IAccountRepository
{
    private readonly PitchOrderDbContext _context;

    public AccountRepository(PitchOrderDbContext context)
    {
        _context = context;
    }

    public async Task<Account> GetByEmailAsync(string email)
    {
        return await _context.Accounts.SingleOrDefaultAsync(a => a.Email == email);
    }

    public async Task CreateAsync(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }
}
