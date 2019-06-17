using System.Collections.Generic;
using System.Threading.Tasks;
using ShopApi.Domain.Models;

namespace ShopApi.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(long id);

    }
}
