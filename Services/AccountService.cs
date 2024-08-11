using System.Collections.Generic;
using System.Threading.Tasks;
using TestApiPitchOrder.Models;
using TestApiPitchOrder.Repository;
using TestApiPitchOrder.Services;

namespace TestApiPitchOrder.Services
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository) : base(accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _accountRepository.GetAccounts();
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _accountRepository.GetAccountById(id);
        }

        public async Task<Account> GetAccountByName(string name)
        {
            return await _accountRepository.GetAccountByName(name);
        }

        public async Task AddAccount(Account account)
        {
            await _accountRepository.Insert(account);
        }

        public async Task UpdateAccount(Account account)
        {
            await _accountRepository.Update(account);
        }

        public async Task DeleteAccount(int id)
        {
            await _accountRepository.Delete(id);
        }
    }
}
