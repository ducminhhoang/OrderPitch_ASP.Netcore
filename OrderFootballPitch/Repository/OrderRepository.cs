using OrderFootballPitch.Models;
using OrderFootballPitch.Data;
using Microsoft.EntityFrameworkCore;

namespace OrderFootballPitch.Repository
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

        public async Task<FootballPitch> GetFootballPitchById(int footballPitchId)
        {
            return await _context.FootballPitches.FindAsync(footballPitchId);
        }

        public async Task<bool> CheckDisountCode(string code)
        {
            return await _context.Discounts.AnyAsync(d => d.Code == code);
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
