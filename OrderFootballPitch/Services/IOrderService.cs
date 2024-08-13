using OrderFootballPitch.Models;

namespace OrderFootballPitch.Services
{
    public interface IOrderService: IBaseService<Order>
    {
        //public Pagging<Customer> GetCustomers(CustomerFilter customerFilter);
        public Task<IEnumerable<Order>> GetOrdersByIdCustomer(int idCustomer);
    }
}
