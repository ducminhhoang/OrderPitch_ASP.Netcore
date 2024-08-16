using TestApiPitchOrder.Repository;
using TestApiPitchOrder.DTOs;
using TestApiPitchOrder.Models;
 
namespace TestApiPitchOrder.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(Account account);
        Task<string> LoginAsync(AccountDTO account);
    }
}

