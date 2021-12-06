using Lab7Hopefully.Models;
using Lab7Hopefully.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7Hopefully.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _orderRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrders(int id)
        {
            return await _orderRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrders([FromBody] Order order)
        {
            var newOrder = await _orderRepository.Create(order);
            return CreatedAtAction(nameof(GetOrders), new { id = newOrder.ID }, newOrder);
        }

        [HttpPut]
        public async Task<ActionResult> PutOrders(int id, [FromBody] Order order)
        {
            if(id != order.ID)
            {
                return BadRequest();
            }
            await _orderRepository.Update(order);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrders(int id)
        {
            var orderToDelete = await _orderRepository.Get(id);
            if (orderToDelete ==null)
            {
                return NotFound();
            }
            await _orderRepository.Delete(id);
            return NoContent();
        }
    }
}
