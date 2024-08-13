using OrderFootballPitch.Models;

namespace OrderFootballPitch.Services
{
    public interface IAccountService : IBaseService<Account>
    {
        Task<Account> GetAccountByName(string name);
    }
}
