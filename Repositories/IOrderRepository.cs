using Lab7Hopefully.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7Hopefully.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> Get();
        Task<Order> Get(int id);
        Task<Order> Create(Order order);
        Task Update(Order order);
        Task Delete(int id);
    }
}
