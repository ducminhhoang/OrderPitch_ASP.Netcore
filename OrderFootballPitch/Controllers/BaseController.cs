using Microsoft.AspNetCore.Mvc;
using OrderFootballPitch.Services;

namespace OrderFootballPitch.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        IBaseService<T> _baseService;
        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
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


        [HttpPost]
        public async Task<IActionResult> Post(T entity)
        {
            var res = _baseService.Insert(entity);
            if (res != null)
            {
                return StatusCode(201, res);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpGet("{entityId}")]
        public async Task<IActionResult> GetById(int entityId)
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


        [HttpPut("{entityId}")]
        public async Task<IActionResult> Put([FromBody] T entity)
        {
            try
            {
                await _baseService.Update(entity);
                return Ok("Sửa thành công");
            }
            catch (Exception ex)
            {
                return NoContent();
            } 
        }


        [HttpDelete("{entityId}")]
        public async Task<IActionResult> Delete(int entityId)
        {
            try
            {
                await _baseService.Delete(entityId);
                return Ok("Xóa thành công");
            }
            catch
            {
                return NoContent();
            }
        }
    }
}
