using OrderFootballPitch.Models;
using OrderFootballPitch.DTOs;

namespace OrderFootballPitch.Services
{
    public interface IOrderService: IBaseService<Order>
    {
        public Task<Pagging<Order>> GetOrdersPagging(int page, int pageSize);
        public Task<IEnumerable<Order>> GetOrdersByIdCustomer(int idCustomer);
    }
}
