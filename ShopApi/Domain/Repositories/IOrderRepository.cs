using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Communication;
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
