using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Domain.Models;
using ShopApi.Domain.Services;
using ShopApi.Extensions;
using ShopApi.Resources;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // Adds new client's order
        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] SaveOrderResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var order = _mapper.Map<SaveOrderResource, Order>(resource);
            var result = await _orderService.SaveOrderAsync(order);

            if (!result.Success)
                return BadRequest(result.Message);

            var orderResource = _mapper.Map<Order, OrderResource>(result.Order);

            return Ok(orderResource);
        }

        // Returns all non-deleted orders created by users with given id
        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderResource>> GetClientsOrderAsync(long id)
        {
            var orders = await _orderService.GetClientsOrderAsync(id);
            var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
            return resources;
        }

        // Changes order status to deleted
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOrderByIdAsync(long id)
        {
            var result = await _orderService.RemoveOrderByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            ;

            return Ok(result.Order);
        }
    }
}