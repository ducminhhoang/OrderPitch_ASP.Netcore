
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

public class AuthService : IAuthService
{
    private readonly IAccountRepository _accountRepository;
    private readonly string _secretKey = "your_secret_key"; // Nên lưu trữ bí mật này ở nơi an toàn hơn

    public AuthService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<bool> RegisterAsync(Account account)
    {
        var existingAccount = await _accountRepository.GetByEmailAsync(account.Email);
        if (existingAccount != null)
        {
            return false; // Email đã tồn tại
        }

        account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
        await _accountRepository.CreateAsync(account);
        return true;
    }

    public async Task<string> LoginAsync(Account account)
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
        var key = Encoding.ASCII.GetBytes(_secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Name, account.Name)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }


}