using Microsoft.AspNetCore.Mvc;
using TestApiPitchOrder.Services;
using TestApiPitchOrder.DTOs;
using TestApiPitchOrder.Models;

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

        [HttpGet("GetAllPitch")]
        public async Task<IActionResult> GetAllPitches()
        {
            var pitches = await _footballPitchService.GetAllPitchesAsync();
            return Ok(pitches);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPitchPagging(int page = 1, int pageSize = 8)
        {
            var pitches = await _footballPitchService.GetPitchPagging(page, pageSize);
            return Ok(pitches);
        }

        [HttpGet("GetPitchById/{id}")]
        public async Task<IActionResult> GetPitchById(int id)
        {
            var pitch = await _footballPitchService.GetPitchByIdAsync(id);
            if (pitch == null)
                return NotFound();
            return Ok(pitch);
        }

        [HttpPost("CreatePitch")]
        public async Task<IActionResult> CreatePitch([FromBody] FootballPitchDTO pitchDto)
        {
            var result = await _footballPitchService.CreatePitchAsync(pitchDto);
            return CreatedAtAction(nameof(GetPitchById), new { id = result.Id }, result);
        }

        [HttpPut("UpdatePitch/{id}")]
        public async Task<IActionResult> UpdatePitch(int id, [FromBody] FootballPitchDTO pitchDto)
        {
            var result = await _footballPitchService.UpdatePitchAsync(id, pitchDto);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut("UpdatePitch")]
        public async Task<IActionResult> UpdatePitch(FootballPitch footballPitch)
        {
            await _footballPitchService.UpdatePitch(footballPitch);
            return Ok("Updated successfully");
        }
        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeletePitch(int id)
        {
            var success = await _footballPitchService.DeletePitchAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpGet("SearchByName")]
        public async Task<IActionResult> SearchPitchesByName(string name)
        {
            var pitches = await _footballPitchService.SearchPitchesByNameAsync(name);
            return Ok(pitches);
        }

    }
}
