using Microsoft.AspNetCore.Mvc;
using OrderFootballPitch.Models;
using OrderFootballPitch.Repository;
using OrderFootballPitch.Services;

namespace OrderFootballPitch.Controllers
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
    }
}
