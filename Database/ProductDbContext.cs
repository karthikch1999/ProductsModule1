using Microsoft.EntityFrameworkCore;
using ProductsModule1.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsModule1.Database
{
    public class ProductDbContext:DbContext 
    {
        public DbSet<Product> Products { get; set; }
  

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
    }
}
