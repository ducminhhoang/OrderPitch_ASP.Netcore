using TestApiPitchOrder.DTOs;
using TestApiPitchOrder.Models;
namespace TestApiPitchOrder.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<bool> CheckOrderTime(int pitchId, DateTime startAt, DateTime endAt);

        Task<Discount> CheckDisountCode(string code);

        Task<string> GetCustomerNameById(int customerId);

        Task<FootballPitch> GetFootballPitchById(int footballPitchId);

        Task<string> GetPitchNameById(int pitchId);

        Task<double> GetDepositeById(int orderId);

        Task<Bank> GetBankById(int bankid);

        Task<IEnumerable<Bank>> GetBanks();
        Task<ThongKe> statistical();

        Task<PaggingDTO<Order>> GetOrdersByCustomerId(int customerId, int page, int pageSize);
        Task<PaggingDTO<Order>> GetOrdersPagging(int page, int pageSize);

        Task<string> GetStatusOrderById(int orderId);
    }
}
