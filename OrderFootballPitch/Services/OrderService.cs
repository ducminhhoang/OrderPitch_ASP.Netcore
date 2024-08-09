using OrderFootballPitch.CustomExceptions;
using OrderFootballPitch.Models;
using OrderFootballPitch.Repository;

namespace OrderFootballPitch.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
        }

        protected override async Task ValidateCustom(Order entity, bool isInsert)
        {
            if (entity is Order)
            {
                var order = entity as Order;

                // Kiểm tra thời gian bắt đầu phải nhỏ hơn thời gian kết thúc
                if (order.StartAt >= order.EndAt)
                {
                    throw new OrderException("Start time must be less than end time.");
                }

                // Kiểm tra thời gian đặt trước ít nhất 2 tiếng
                if (order.StartAt <= DateTime.Now.AddHours(2))
                {
                    throw new OrderException("Order must be made at least 2 hours in advance.");
                }

                // Kiểm tra trùng thời gian đặt sân
                bool isTimeConflict = await _orderRepository.CheckOrderTime(order.FootballPitchId, order.StartAt, order.EndAt);
                if (isTimeConflict)
                {
                    throw new OrderException("Order time overlaps with another order.");
                }

                // Kiểm tra thời gian đặt sân có nằm trong khoảng thời gian mở cửa
                var pitch = await _orderRepository.GetFootballPitchById(order.FootballPitchId);
                if (order.StartAt.TimeOfDay < pitch.TimeStart || order.EndAt.TimeOfDay > pitch.TimeEnd)
                {
                    throw new OrderException("Order time are outside opening hours.");
                }
                Console.WriteLine("Kiem tra xong");
            }
            else
            {
                throw new OrderException("Value Error");
            }    
        }

        public async Task<IEnumerable<Order>> GetOrdersByIdCustomer(int IdCustomer)
        {
            return await _orderRepository.GetOrdersByIdCustomer(IdCustomer);
        }
    }
}
