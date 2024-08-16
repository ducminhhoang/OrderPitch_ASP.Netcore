using System.Collections.Generic;
using System.Threading.Tasks;
using TestApiPitchOrder.Services;
using TestApiPitchOrder.Models;


namespace TestApiPitchOrder.Services
{
    public interface IAccountService : IBaseService<Account>
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccountById(int id);
        Task<Account> GetByEmailAsync(string email);
        Task<Account> GetAccountByName(string name);
        Task AddAccount(Account account);
        Task UpdateAccount(Account account);
        Task DeleteAccount(int id);
    }
}
