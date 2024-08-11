using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestApiPitchOrder.Controllers;
using TestApiPitchOrder.Models;
using TestApiPitchOrder.Services;

namespace TestApiPitchOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController<Account>
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService) : base(accountService)
        {
            _accountService = accountService;
        }
       
        [HttpGet("GetAccounts")]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _accountService.GetAccounts();
            return Ok(accounts);
        }

        [HttpGet("GetAccountById/{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var account = await _accountService.GetAccountById(id);
            if (account != null)
            {
                return Ok(account);
            }
            return NotFound();
        }

        [HttpGet("GetAccountByName/{name}")]
        public async Task<IActionResult> GetAccountByName(string name)
        {
            var account = await _accountService.GetAccountByName(name);
            if (account != null)
            {
                return Ok(account);
            }
            return NotFound();
        }

        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount(Account account)
        {
            await _accountService.AddAccount(account);
            return StatusCode(201);
        }

        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount(Account account)
        {
            await _accountService.UpdateAccount(account);
            return Ok("Updated successfully");
        }

        [HttpDelete("DeleteAccount/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            await _accountService.DeleteAccount(id);
            return Ok("Deleted successfully");
        }
    }
}
