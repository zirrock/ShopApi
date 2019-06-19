using System;
using System.Collections.Generic;
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

        public async Task<Client> GetClientByCredentialsAsync(string name, string surname, string login)
        {
            return await _clientRepository.GetClientByCredentials(name, surname, login);
        }

        public async Task<ClientResponse> SaveClientAsync(Client client)
        {
            try
            {
                await _clientRepository.AddClientAsync(client);
                await _unitOfWork.CompleteAsync();

                return new ClientResponse(client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ClientResponse($"An error has occurred while saving the client: {e.Message}");
            }
        }

        public async Task<ClientResponse> UpdateClientAsync(long id, Client client)
        {
            var existingClient = await _clientRepository.GetClientByIdAsync(id);

            if (existingClient == null) return new ClientResponse("Client not found");

            existingClient.Name = client.Name;
            existingClient.Surname = client.Surname;
            existingClient.Login = client.Login;
            existingClient.Email = client.Email;
            existingClient.Phone = client.Phone;

            try
            {
                _clientRepository.UpdateClient(existingClient);
                await _unitOfWork.CompleteAsync();

                return new ClientResponse(existingClient);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new ClientResponse($"An error has occurred when updating the client: {e.Message}");
            }
        }
    }
}