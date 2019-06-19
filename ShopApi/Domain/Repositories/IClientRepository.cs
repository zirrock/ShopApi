using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApi.Domain.Models;

namespace ShopApi.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(long id);
        Task<Client> GetClientByCredentials(string name, string surname, string login);
        Task AddClientAsync(Client client);
        void UpdateClient(Client client);
    }
}