using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderFootballPitch.Data;
using OrderFootballPitch.Models;
using OrderFootballPitch.Services;
using System.Text;

namespace OrderFootballPitch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : BaseController<Account>
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService) : base(accountService)
        {
            _accountService = accountService;
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
    }
}
