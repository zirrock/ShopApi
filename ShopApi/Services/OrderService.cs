using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApi.Communication;
using ShopApi.Domain.Models;
using ShopApi.Domain.Repositories;
using ShopApi.Domain.Services;

namespace ShopApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IClientRepository clientRepository,
            IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderResponse> SaveOrderAsync(Order order)
        {
            try
            {
                var existingClient = await _clientRepository.GetClientByIdAsync(order.ClientId);

                if (existingClient == null) return new OrderResponse("Client not found");

                await _orderRepository.AddOrderAsync(order);
                await _unitOfWork.CompleteAsync();

                return new OrderResponse(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new OrderResponse($"An error has occurred while adding the order: {e.Message}");
            }
        }

        public async Task<IEnumerable<Order>> GetClientsOrderAsync(long id)
        {
            return await _orderRepository.GetClientsOrderByIdAsync(id);
        }

        public async Task<OrderResponse> RemoveOrderByIdAsync(long id)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(id);

            if (existingOrder == null) return new OrderResponse("Order not found");

            existingOrder.IsDeleted = true;

            try
            {
                _orderRepository.UpdateOrder(existingOrder);
                await _unitOfWork.CompleteAsync();

                return new OrderResponse(existingOrder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new OrderResponse($"An error has occurred when updating the client: {e.Message}");
            }
        }
    }
}