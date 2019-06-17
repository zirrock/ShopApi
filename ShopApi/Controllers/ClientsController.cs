using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Models;
using ShopApi.Domain.Services;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> GetClients()
        {
            var clients = await _clientService.GetClientsAsync();
            return clients;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(long id)
        {
            var client = await _clientService.GetClientByIdAsync(id);  

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

//        [HttpPost]
//        public async Task<ActionResult<Client>> AddClient(Client client)
//        {
//            _context.Clients.Add(client);
//            await _context.SaveChangesAsync();
//
//            return CreatedAtAction(nameof(GetClient), new {id = client.Id}, client);
//        }
//
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteClient(long id)
//        {
//            var client = await _context.Clients.FindAsync(id);
//
//            if (client == null)
//            {
//                return NotFound();
//            }
//
//            _context.Clients.Remove(client);
//            await _context.SaveChangesAsync();
//
//            return NoContent();
//        }

    }
}
