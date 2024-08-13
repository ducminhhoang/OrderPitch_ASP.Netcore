using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFootballPitch.DTOs;
using OrderFootballPitch.Models;
using OrderFootballPitch.Services;

namespace OrderFootballPitch.Controllers
{
    //[Authorize(Policy = "CustomerAndAdmin")]
    public class BaseController<T> : Controller where T : class
    {
        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
            var entities = await _baseService.GetAll();

            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }
            catch (Exception ex)
            {
            }
        }

        {
            {
            }
            else
            {
                return NoContent();
            }
        }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        {
            {
            }
            else
            {
                return NoContent();
            }
        }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPut("{entityId}")]
        {
            try
            {
            }
            catch (Exception ex)
            {
            } 
        }


        [HttpDelete("{entityId}")]
        public async Task<IActionResult> Delete(int entityId)
        {
            try
            {
                await _baseService.Delete(entityId);
            }
            {
            }
        }
    }
}
