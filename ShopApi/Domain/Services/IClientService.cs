using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApi.Communication;
using ShopApi.Domain.Models;

namespace ShopApi.Domain.Services
{
    public interface IClientService
    {
        // Returns list of all clients
        Task<IEnumerable<Client>> GetClientsAsync();

        // Returns first client found with given name, surname and login
        Task<Client> GetClientByCredentialsAsync(string name, string surname, string login);

        // Adds a new client
        Task<ClientResponse> SaveClientAsync(Client client);

        // Updates client data
        Task<ClientResponse> UpdateClientAsync(long id, Client client);
    }
}