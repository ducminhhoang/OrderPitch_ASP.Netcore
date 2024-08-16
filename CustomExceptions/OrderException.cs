using TestApiPitchOrder.Models;

namespace TestApiPitchOrder.CustomExceptions
{
    public class OrderException : BaseException<Order>
    {
        public OrderException(string msg) : base(msg)
        {
        }
        public OrderException(string msg, string entityCode) : base(msg)
        {
        }
    }
}
