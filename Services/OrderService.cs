using TestApiPitchOrder.CustomExceptions;
using TestApiPitchOrder.DTOs;
using TestApiPitchOrder.Models;
using TestApiPitchOrder.Repository;

namespace TestApiPitchOrder.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ThongKe> statistical()
        {
            return await _orderRepository.statistical();
        }
        public async Task<PaggingDTO<Order>> GetOrdersPagging(int page, int pageSize)
        {
            return await _orderRepository.GetOrdersPagging(page, pageSize);
        }
        public async Task<IEnumerable<Bank>> GetBanks()
        {
            return await _orderRepository.GetBanks();
        }
        public async Task<PaggingDTO<Order>> GetOrdersByCustormerId(int customerId, int page, int pageSize)
        {
            return await _orderRepository.GetOrdersByCustomerId(customerId, page, pageSize);
        }
        public async Task<Discount> CheckDiscountCode(string code)
        {
            return await _orderRepository.CheckDisountCode(code);
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
            }
            else
            {
                throw new OrderException("Value Error");
            }
        }
    }
}
