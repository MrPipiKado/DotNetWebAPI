using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7Hopefully.Models
{
    public class OrderContext: DbContext
    {
        public OrderContext(DbContextOptions options) :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Order> orders { get; set; }
    }
}
