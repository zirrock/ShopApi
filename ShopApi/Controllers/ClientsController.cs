using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Models;
using ShopApi.Domain.Services;
using ShopApi.Extensions;
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
        public async Task<IEnumerable<ClientResource>> GetClientList()
        {
            var clients = await _clientService.GetClientsAsync();
            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(clients);
            return resources;
        }

        [HttpGet("credentials")]
        public async Task<ClientResource> GetClientByCredentials([FromBody] SearchClientResource resource)
        {
            var client = await _clientService.GetClientByCredentialsAsync(resource.Name, resource.Surname, resource.Login);
            var clientResource = _mapper.Map<Client, ClientResource>(client);

            return clientResource;
        }

        [HttpPost]
        public async Task<IActionResult> AddClientAsync([FromBody] SaveClientResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var client = _mapper.Map<SaveClientResource, Client>(resource);
            var result = await _clientService.SaveClientAsync(client);

            if (!result.Success)
                return BadRequest(result.Message);

            var clientResource = _mapper.Map<Client, ClientResource>(result.Client);

            return Ok(clientResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClientAsync(long id, [FromBody] SaveClientResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var client = _mapper.Map<SaveClientResource, Client>(resource);
            var result = await _clientService.UpdateClientAsync(id, client);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var clientResource = _mapper.Map<Client, ClientResource>(result.Client);
            return Ok(clientResource);
        }

    }
}
