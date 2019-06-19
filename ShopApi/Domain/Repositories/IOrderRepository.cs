using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApi.Domain.Models;

namespace ShopApi.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(long id);
        Task AddOrderAsync(Order order);
        Task<IEnumerable<Order>> GetClientsOrderByIdAsync(long id);
        void UpdateOrder(Order order);
    }
}