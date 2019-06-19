using System.Collections.Generic;
using System.Threading.Tasks;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using ShopApi.Communication;
using ShopApi.Domain.Models;

namespace ShopApi.Domain.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetClientByCredentialsAsync(string name, string surname, string login);
        Task<SaveClientResponse> SaveClientAsync(Client client);
        Task<SaveClientResponse> UpdateClientAsync(long id, Client client);

    }
}
