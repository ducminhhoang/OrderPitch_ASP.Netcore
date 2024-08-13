using OrderFootballPitch.Models;

namespace OrderFootballPitch.Services
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository) : base(accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetAccountByName(string name)
        {
            return await _accountRepository.GetAccountByName(name);
        }
    }
}
