using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestApiPitchOrder.Models;
using TestApiPitchOrder.DTOs;
using TestApiPitchOrder.Repository;

namespace TestApiPitchOrder.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        public async Task<bool> RegisterAsync(Account account)
        {
            var existingAccount = await _accountRepository.GetByEmailAsync(account.Email);
            if (existingAccount != null)
            {
                return false; // Email đã tồn tại
            }

            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            account.CreatedAt = DateTime.UtcNow;
            account.AccountTypeId = 2;
            await _accountRepository.AddAccount(account);
            return true;
        }

        public async Task<string> LoginAsync(AccountDTO account)
        {
            var existingAccount = await _accountRepository.GetByEmailAsync(account.Email);

            if (existingAccount == null || !BCrypt.Net.BCrypt.Verify(account.Password, existingAccount.Password))
            {
                return null; // Đăng nhập không thành công
            }
            
            return GenerateJwtToken(existingAccount);
        }

        private string GenerateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.AccountTypeId == 1 ? "Admin" : "Customer"),
                new Claim(ClaimTypes.Name, account.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
