using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Data
{
    public class FoodserviceContext : DbContext
    {
        public FoodserviceContext(DbContextOptions<FoodserviceContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}
