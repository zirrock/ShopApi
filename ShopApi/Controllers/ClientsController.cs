﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Models;
using ShopApi.Domain.Services;
using ShopApi.Resources;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientsController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClientResource>> GetClients()
        {
            var clients = await _clientService.GetClientsAsync();
            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<ClientResource> GetClient(long id)
        {
            var client = await _clientService.GetClientByIdAsync(id);

            if (client == null)
            {
                return null;
            }

            var resource = _mapper.Map<Client, ClientResource>(client);

            return resource;
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
