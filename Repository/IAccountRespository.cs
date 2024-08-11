
using OrderFootballPitch.Repository;
using TestApiPitchOrder.Models;

namespace TestApiPitchOrder.Repository
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccounts();

        Task<Account> GetAccountById(int id);
        Task<Account> GetAccountByName(string name);
        Task AddAccount(Account account);

        Task<Account> Insert(Account account);

        Task Update(Account account);

        Task Delete(int id);
    }
}
