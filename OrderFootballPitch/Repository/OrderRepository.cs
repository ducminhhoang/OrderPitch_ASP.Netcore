using OrderFootballPitch.Models;
using OrderFootballPitch.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using OrderFootballPitch.CustomExceptions;
using OrderFootballPitch.DTOs;

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

        public async Task<IEnumerable<Order>> GetOrdersByIdCustomer(int idCustomer)
        {
            var customer = await _context.Accounts.FindAsync(idCustomer);
            if (customer == null)
            {
                throw new OrderException("Customer Error");
            }
            else
            {
                if (customer.AccountTypeId != 2)
                {
                    throw new OrderException("Customer role required");
                }
                else
                {
                    return await _context.Orders.Where(o => o.AccountId == idCustomer).ToListAsync();
                }    
            }
        }

        public async Task<Pagging<Order>> GetOrdersPagging(int page, int pageSize)
        {
            var query = _context.Orders.AsQueryable();

            var totalItems = await query.CountAsync();
            var orders = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(o => new Order
                {
                    Id = o.Id,
                    Name = o.Name,
                    Phone = o.Phone,
                    Email = o.Email,
                    Total = o.Total,
                    StartAt = o.StartAt,
                    EndAt = o.EndAt,
                    Status = o.Status,
                    CreatedAt = o.CreatedAt,
                    UpdatedAt = o.UpdatedAt,
                    Deposit = o.Deposit,
                    DiscountId = o.DiscountId,
                    FootballPitchId = o.FootballPitchId,
                    AccountId = o.AccountId,
                    BankId = o.BankId,
                    Note = o.Note
                })
                .ToListAsync();

            return new Pagging<Order>
            {
                Items = orders,
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize)
            };
        }
    }
}
