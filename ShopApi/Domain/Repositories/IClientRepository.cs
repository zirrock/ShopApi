using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopApi.Communication;
using ShopApi.Domain.Models;

namespace ShopApi.Domain.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(long id);
        Task AddClientAsync(Client client);
        void UpdateClient(Client client);
    }
}
