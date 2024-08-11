using Microsoft.AspNetCore.Mvc;
using OrderFootballPitch.Services;
using OrderFootballPitch.DTOs;
using OrderFootballPitch.Models;

namespace OrderFootballPitch.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FootballPitchController : ControllerBase
    {
        private readonly IFootballPitchService _footballPitchService;

        public FootballPitchController(IFootballPitchService footballPitchService)
        {
            _footballPitchService = footballPitchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPitches()
        {
            var pitches = await _footballPitchService.GetAllPitchesAsync();
            return Ok(pitches);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPitchById(int id)
        {
            var pitch = await _footballPitchService.GetPitchByIdAsync(id);
            if (pitch == null)
                return NotFound();
            return Ok(pitch);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePitch([FromBody] FootballPitchDTO pitchDto)
        {
            var result = await _footballPitchService.CreatePitchAsync(pitchDto);
            return CreatedAtAction(nameof(GetPitchById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePitch(int id, [FromBody] FootballPitchDTO pitchDto)
        {
            var result = await _footballPitchService.UpdatePitchAsync(id, pitchDto);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePitch(int id)
        {
            var success = await _footballPitchService.DeletePitchAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchPitchesByName(string name)
        {
            var pitches = await _footballPitchService.SearchPitchesByNameAsync(name);
            return Ok(pitches);
        }

    }
}
