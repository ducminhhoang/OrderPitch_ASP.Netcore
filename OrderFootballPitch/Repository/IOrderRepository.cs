using OrderFootballPitch.Models;

namespace OrderFootballPitch.Repository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<bool> CheckOrderTime(int pitchId, DateTime startAt, DateTime endAt);

        Task<bool> CheckDisountCode(string code);

        Task<string> GetCustomerNameById(int customerId);

        Task<FootballPitch> GetFootballPitchById(int footballPitchId);

        Task<string> GetPitchNameById(int pitchId);

        Task<double> GetDepositeById(int orderId);

        Task<Bank> GetBankById(int bankid);

        Task<IEnumerable<Bank>> GetBanks();

        Task<string> GetStatusOrderById(int orderId);

        Task<IEnumerable<Order>> GetOrdersByIdCustomer(int idCustomer);
    }
}
