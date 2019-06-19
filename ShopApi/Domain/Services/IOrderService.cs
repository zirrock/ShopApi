using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Communication;
using ShopApi.Domain.Models;

namespace ShopApi.Domain.Services
{
    public interface IOrderService
    {
        Task<SaveOrderResponse> SaveOrderAsync(Order order);
        Task<IEnumerable<Order>> GetClientsOrderAsync(long id);
        Task<SaveOrderResponse> RemoveOrderByIdAsync(long id);
    }
}
