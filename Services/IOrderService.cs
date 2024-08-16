
using TestApiPitchOrder.DTOs;
using TestApiPitchOrder.Models;

namespace TestApiPitchOrder.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        //public Pagging<Customer> GetCustomers(CustomerFilter customerFilter);
        Task<IEnumerable<Bank>> GetBanks();
        Task<PaggingDTO<Order>> GetOrdersByCustormerId(int customerId, int page, int pageSize);
        Task<PaggingDTO<Order>> GetOrdersPagging(int page, int pageSize);
        Task<Discount> CheckDiscountCode(string code);
        Task<ThongKe> statistical();
    }
}
