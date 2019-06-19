using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Communication;
using ShopApi.Domain.Models;
using ShopApi.Domain.Repositories;
using ShopApi.Domain.Services;

namespace ShopApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SaveOrderResponse> SaveOrderAsync(Order order)
        {
            try
            {
                var existingClient = await _clientRepository.GetClientByIdAsync(order.ClientId);

                if (existingClient == null)
                {
                    return new SaveOrderResponse("Client not found");
                }

                await _orderRepository.AddOrderAsync(order);
                await _unitOfWork.CompleteAsync();

                return new SaveOrderResponse(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new SaveOrderResponse($"An error has occurred while adding the order: {e.Message}");
            }
        }

        public async Task<IEnumerable<Order>> GetClientsOrderAsync(long id)
        {
            return await _orderRepository.GetClientsOrderByIdAsync(id);
        }
    }
}
