using Microsoft.IdentityModel.Tokens;
using OrderFootballPitch.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
public interface IAuthService
{
    Task<bool> RegisterAsync(Account account);
    Task<string> LoginAsync(Account account);
}