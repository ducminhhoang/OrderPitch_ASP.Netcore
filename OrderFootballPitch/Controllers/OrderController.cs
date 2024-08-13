using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderFootballPitch.DTOs;
using OrderFootballPitch.Models;
using OrderFootballPitch.Repository;
using OrderFootballPitch.Services;


namespace OrderFootballPitch.Controllers
{
    //[Authorize(Roles = "admin, customer")]
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class OrderController : BaseController<Order>
    {
        IOrderService _orderService;

        public OrderController(IOrderService orderService, IOrderRepository OrderRepository) : base(orderService)
        {
            _orderService = orderService;
        }

        //[Authorize(Roles = "customer")]
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

        [HttpPut("eidt/{entityId}")]
        public async Task<IActionResult> Put(int entityId, [FromBody] OrderDTO entity)
        {
            try
            {
                var existingOrder = await _orderService.GetById(entityId);
                if (existingOrder == null)
                {
                    return NotFound();
                }
                existingOrder.Name = entity.Name;
                existingOrder.Phone = entity.Phone;
                existingOrder.Email = entity.Email;
                existingOrder.Deposit = entity.Deposit;
                existingOrder.StartAt = entity.StartAt;
                existingOrder.EndAt = entity.EndAt;
                existingOrder.Total = entity.Total;
                existingOrder.Status = (StatusOrder)entity.Status;
                existingOrder.Note = entity.Note;
                existingOrder.DiscountId = entity.DiscountId;
                existingOrder.BankId = entity.BankId;
                existingOrder.UpdatedAt = DateTime.UtcNow;

                await _orderService.Update(existingOrder);
                return Ok(new { Message = "Sửa thành công" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        //[Authorize(Roles = "customer")]
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

        // GET api/v1/orders?page=1
        //[Authorize(Roles = "admin, customer")]
        [HttpGet("list")]
        public async Task<IActionResult> GetAllPage([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var orders = await _orderService.GetOrdersPagging(page, pageSize);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
