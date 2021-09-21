using Microsoft.AspNetCore.Mvc;
using ProductsModule1.Database;
using ProductsModule1.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsModule1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMicroServicesController : ControllerBase
    {
         private readonly ProductDbContext _db;
        public ProductMicroServicesController(ProductDbContext db)
        {
            _db = db;
        }
        // GET: api/<ProductMicroServicesController>
        [HttpGet("{id:int}")]
      
        public async Task<ActionResult<Product>> SearchProductById(int id)
        {
            Product product = await _db.Products.FindAsync(id);

            return product;
        }

        // GET api/<ProductMicroServicesController>/5
        [HttpGet("{name}")]
        public  Product SearchProductByName(string name)
        {
            Product product =  _db.Products.Where(s=>s.Name.Contains(name)).FirstOrDefault();

            return product;
        }

        // POST api/<ProductMicroServicesController>
        [HttpPost("AddProductRating/{id}")]
        public async Task<IActionResult> AddProductRating([FromRoute] int id, [FromBody] AvgRating  rating)
        {
            Product product = await _db.Products.FindAsync(id);
            decimal overallRating = (product.Rating + rating.Rating) / 2;
            product.Rating = overallRating;
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return Ok();
        }
        public class AvgRating
        {
            public decimal Rating { get; set; }
        }

   
    }
}
