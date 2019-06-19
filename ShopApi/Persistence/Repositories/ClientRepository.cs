using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Models;
using ShopApi.Domain.Repositories;
using ShopApi.Persistence.Contexts;

namespace ShopApi.Persistence.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository(ShopApiContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(long id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> GetClientByCredentials(string name, string surname, string login)
        {
            return await _context.Clients.FirstOrDefaultAsync(p => p.Name == name && p.Surname == surname && p.Login == login);
        }

        public async Task AddClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
        }

        public void UpdateClient(Client client)
        {
            _context.Clients.Update(client);
        }
    }
}
