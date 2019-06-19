using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Models;
using ShopApi.Domain.Repositories;
using ShopApi.Persistence.Contexts;

namespace ShopApi.Persistence.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(ShopApiContext context) : base(context)
        {
        }

        public async Task<Order> GetOrderByIdAsync(long id)
        {
            return await _context.Orders.Include(p => p.Client).FirstAsync(p => p.Id == id);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task<IEnumerable<Order>> GetClientsOrderByIdAsync(long id)
        {
            return await _context.Orders.Include(p => p.Client).Where(p => p.ClientId == id).Where(p => !p.IsDeleted)
                .ToListAsync();
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
        }
    }
}