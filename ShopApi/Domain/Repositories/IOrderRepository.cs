using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Domain.Models;

namespace ShopApi.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task<IEnumerable<Order>> GetClientsOrderByIdAsync(long id);
    }
}
