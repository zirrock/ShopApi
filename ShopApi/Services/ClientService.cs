using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Communication;
using ShopApi.Domain.Models;
using ShopApi.Domain.Repositories;
using ShopApi.Domain.Services;

namespace ShopApi.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _clientRepository.GetClientsAsync();
        }

        public async Task<Client> GetClientByIdAsync(long id)
        {
            return await _clientRepository.GetClientByIdAsync(id);
        }

        public async Task<SaveClientResponse> SaveClientAsync(Client client)
        {
            try
            {
                await _clientRepository.AddClientAsync(client);
                await _unitOfWork.CompleteAsync();

                return new SaveClientResponse(client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new SaveClientResponse($"An error has occurred while saving the client: {e.Message}");
            }
        }

        public async Task<SaveClientResponse> UpdateClientAsync(long id, Client client)
        {
            var existingClient = await _clientRepository.GetClientByIdAsync(id);

            if (existingClient == null)
            {
                return new SaveClientResponse("Client not found");
            }

            existingClient.Name = client.Name;
            existingClient.Surname = client.Surname;
            existingClient.Login = client.Login;
            existingClient.Email = client.Email;
            existingClient.Phone = client.Phone;

            try
            {
                _clientRepository.UpdateClient(existingClient);
                await _unitOfWork.CompleteAsync();

                return new SaveClientResponse(existingClient);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new SaveClientResponse($"An error has occurred when updating the client: {e.Message}");
            }
        }
    }
}
