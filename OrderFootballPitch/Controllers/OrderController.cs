using Microsoft.AspNetCore.Mvc;
using OrderFootballPitch.DTOs;
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
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO orderDto)
        {
            try
            {
                var order = new Order
                {
                    Name = orderDto.Name,
                    Phone = orderDto.Phone,
                    Email = orderDto.Email,
                    Deposit = orderDto.Deposit,
                    StartAt = orderDto.StartAt,
                    EndAt = orderDto.EndAt,
                    Total = orderDto.Total,
                    Status = orderDto.Status,
                    AccountId = orderDto.AccountId,
                    FootballPitchId = orderDto.FootballPitchId,
                    DiscountId = orderDto.DiscountId,
                    BankId = orderDto.BankId,
                    CreatedAt = DateTime.UtcNow
                };
                await _orderService.Insert(order);
                return Ok(new { Message = "Order created successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("Orders/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomer(int customerId)
        {
            var orders = await _orderService.GetOrdersByIdCustomer(customerId);
            if (orders == null || !orders.Any())
            {
                return NotFound(new { Message = $"No orders found for customer with ID {customerId}" });
            }
            return Ok(orders);
        }
    }
}
