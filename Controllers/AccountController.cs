using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApiPitchOrder.Data;
using TestApiPitchOrder.Models;
using TestApiPitchOrder.Services;


namespace TestApiPitchOrder.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : BaseController<Account>
    {
        private readonly IAccountService _accountService;
        private readonly PitchOrderDbContext _context;
        public AccountController(IAccountService accountService,PitchOrderDbContext context) : base(accountService)
        {
            
            _accountService = accountService;
            _context = context;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _accountService.GetAccounts();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var account = await _accountService.GetAccountById(id);
            if (account != null)
            {
                return Ok(account);
            }
            return NotFound();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAccountByName(string name)
        {
            var account = await _accountService.GetAccountByName(name);
            if (account != null)
            {
                return Ok(account);
            }
            return NotFound();
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmailAsync(string email)
        {
            var account = await _accountService.GetByEmailAsync(email);
            if (account != null)
            {
                return Ok(account);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(Account account)
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            await _accountService.AddAccount(account);
            return Ok("Add sucessfully");
        }

        
        [HttpPut]
        public IActionResult UpdateAccount([FromBody] Account account)
        {
            if (account == null || account.Id == 0)
            {
                return BadRequest("Invalid account data.");
            }

            var existingAccount = _context.Accounts.Find(account.Id);
            if (existingAccount == null)
            {
                return NotFound("Account not found.");
            }

            _context.Entry(existingAccount).CurrentValues.SetValues(account);
            _context.SaveChanges();

            return Ok(account);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            await _accountService.DeleteAccount(id);
            return Ok("Deleted successfully");
        }

    }
}
