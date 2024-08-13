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
        private readonly IBaseService<T> _baseService;

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
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{entityId}")]
        public async Task<IActionResult> GetById(int entityId)
        {
            try
            {
                var entity = await _baseService.GetById(entityId);
                if (entity != null)
                {
                    return Ok(entity);
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


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T entity)
        {
            try
        {
                var res = await _baseService.Insert(entity);
                if (res != null)
            {
                    return StatusCode(201, res);
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


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] T entity)
        {
            try
            {
                await _baseService.Update(entity);
                return Ok(new { Message = "Update sucessfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            } 
        }


        [HttpDelete("{entityId}")]
        public async Task<IActionResult> Delete(int entityId)
        {
            try
            {
                await _baseService.Delete(entityId);
                return Ok(new { Message = "Delete Sucessfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
