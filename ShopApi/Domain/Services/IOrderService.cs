using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApi.Communication;
using ShopApi.Domain.Models;

namespace ShopApi.Domain.Services
{
    public interface IOrderService
    {
        // Adds new order
        Task<OrderResponse> SaveOrderAsync(Order order);

        // Returns all orders created by client with given ID
        Task<IEnumerable<Order>> GetClientsOrderAsync(long id);

        // Changes status of order with given ID to "deleted"
        Task<OrderResponse> RemoveOrderByIdAsync(long id);
    }
}