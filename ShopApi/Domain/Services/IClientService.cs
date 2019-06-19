using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApi.Communication;
using ShopApi.Domain.Models;

namespace ShopApi.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(long id);
        Task<SaveClientResponse> SaveClientAsync(Client client);
        Task<SaveClientResponse> UpdateClientAsync(long id, Client client);

    }
}
