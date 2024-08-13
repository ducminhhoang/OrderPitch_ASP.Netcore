using Microsoft.AspNetCore.Mvc;
using OrderFootballPitch.Models;
using OrderFootballPitch.Services;

namespace OrderFootballPitch.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FootballPitchController : BaseController<FootballPitch>
    {
        private readonly IFootballPitchService _footballPitchService;

        public FootballPitchController(IFootballPitchService footballPitchService) : base(footballPitchService)
        {
            _footballPitchService = footballPitchService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPitchesByName(string name)
        {
            var pitches = await _footballPitchService.SearchPitchesByNameAsync(name);
            return Ok(pitches);
        }

    }
}
