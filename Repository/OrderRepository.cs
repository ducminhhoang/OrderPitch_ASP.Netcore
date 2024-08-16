
using TestApiPitchOrder.Data;
using Microsoft.EntityFrameworkCore;
using TestApiPitchOrder.Models;
using TestApiPitchOrder.DTOs;

namespace TestApiPitchOrder.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly PitchOrderDbContext _context;

        public OrderRepository(PitchOrderDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckOrderTime(int pitchId, DateTime startAt, DateTime endAt)
        {
            return await _context.Orders.AnyAsync(o => o.FootballPitchId == pitchId &&
                                                       ((startAt >= o.StartAt && startAt < o.EndAt) ||
                                                        (endAt > o.StartAt && endAt <= o.EndAt)));
        }

        public async Task<ThongKe> statistical()
        {
            var today = DateTime.Today;
            var startOfMonth = new DateTime(today.Year, today.Month, 1);

            var totalOrdersToday = await _context.Orders
                .CountAsync(o => o.CreatedAt.Date == today);

            var totalBillToday = await _context.Orders
                .Where(o => o.CreatedAt.Date == today)
                .SumAsync(o => o.Total);

            var totalOrdersMonth = await _context.Orders
                .CountAsync(o => o.CreatedAt >= startOfMonth);

            var totalBillMonth = await _context.Orders
                .Where(o => o.CreatedAt >= startOfMonth)
                .SumAsync(o => o.Total);
            return new ThongKe
            {
                TotalOrdersToday = totalOrdersToday,
                TotalBillToday = totalBillToday,
                TotalOrdersMonth = totalOrdersMonth,
                TotalBillMonth = totalBillMonth
            };
        }
        public async Task<FootballPitch> GetFootballPitchById(int footballPitchId)
        {
            return await _context.FootballPitches.FindAsync(footballPitchId);
        }

        public async Task<Discount> CheckDisountCode(string code)
        {
            return await _context.Discounts.FirstOrDefaultAsync(d => d.Code == code && d.EndDate >= DateTime.UtcNow);
        }

        public async Task<string> GetCustomerNameById(int customerId)
        {
            var customer = await _context.Accounts.FindAsync(customerId);
            if (customer?.AccountTypeId == 2)
            {
                return customer.Name;
            }
            return null;
        }

        public async Task<string> GetPitchNameById(int pitchId)
        {
            var pitch = await _context.FootballPitches.FindAsync(pitchId);
            return pitch?.Name;
        }

        public async Task<double> GetDepositeById(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                return order.Deposit;
            }
            return 0.0;
        }

        public async Task<IEnumerable<Bank>> GetBanks()
        {
            return await _context.Banks.ToListAsync();
        }

        public async Task<PaggingDTO<Order>> GetOrdersByCustomerId(int customerId, int page, int pageSize)
        {
            var query = _context.Orders.AsQueryable().Where(p => p.AccountId == customerId);
            var orders = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return new PaggingDTO<Order>
            {
                Items = orders,
                PageSize = pageSize,
                PageNumber = page,
                TotalItems = totalItems
            };
        }

        public async Task<PaggingDTO<Order>> GetOrdersPagging(int page, int pageSize)
        {
            var query = _context.Orders.AsQueryable();
            var orders = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return new PaggingDTO<Order>
            {
                Items = orders,
                PageSize = pageSize,
                PageNumber = page,
                TotalItems = totalItems
            };
        }
        public async Task<Bank> GetBankById(int bankid)
        {
            var bank = await _context.Banks.FindAsync(bankid);
            if (bank != null)
            {
                return bank;
            }
            return null;
        }    

        public async Task<string> GetStatusOrderById(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            return order?.Status.ToString();
        }
    }
}
