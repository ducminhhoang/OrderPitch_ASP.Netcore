using OrderFootballPitch.Models;
using OrderFootballPitch.Repository;
public interface IAccountRepository : IBaseRepository<Account>
{
    Task<Account> GetAccountByName(string name);
    Task<Account> GetByEmailAsync(string email);
}