using Lab7Hopefully.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7Hopefully.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;
        public OrderRepository(OrderContext context)
        {
            _context = context;
        }
        public async Task<Order> Create(Order order)
        {
            _context.orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task Delete(int id)
        {
            var orderToDelete = await _context.orders.FindAsync(id);
            _context.orders.Remove(orderToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await Task.FromResult(_context.orders.ToList());
        }

        public async Task<Order> Get(int id)
        {
            return await _context.orders.FindAsync(id);
        }

        public async Task Update(Order order)
        {
            _context.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
