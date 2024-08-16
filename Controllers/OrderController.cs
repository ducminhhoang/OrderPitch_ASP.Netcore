using Microsoft.AspNetCore.Mvc;
using TestApiPitchOrder.Repository;
using TestApiPitchOrder.Models;
using TestApiPitchOrder.Services;
using Microsoft.EntityFrameworkCore;

namespace TestApiPitchOrder.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class OrderController : BaseController<Order>
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService, IOrderRepository OrderRepository) : base(orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("order")]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            try
            {
                await _orderService.Insert(order);
                return Ok(new { Message = "Order created successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("banks")]
        public async Task<IActionResult> GetBankList()
        {
            var entities = await _orderService.GetBanks();

            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("customer")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomerId(int customerId, int page = 1, int pageSize = 10)
        {
            var orders = await _orderService.GetOrdersByCustormerId(customerId, page, pageSize);

            if (orders == null)
            {
                return NotFound(); 
            }

            return Ok(orders); 
        }

        [HttpGet("pagging")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersPagging(int page = 1, int pageSize = 10)
        {
            var orders = await _orderService.GetOrdersPagging(page, pageSize);

            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        [HttpGet("validateCode")]
        public async Task<IActionResult> ValidateDiscountCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("Mã giảm giá không hợp lệ.");
            }

            var codes = await _orderService.CheckDiscountCode(code);
            if (codes != null )
            {
                return Ok(codes);
            }
            else
            {
                return NotFound(new { message = "Mã giảm giá không hợp lệ hoặc đã hết hạn." });
            }
        }

        [HttpGet("totals")]
        public async Task<IActionResult> GetTotals()
        {
            try
            {
                var thongke = await _orderService.statistical();
                if (thongke == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(thongke);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
