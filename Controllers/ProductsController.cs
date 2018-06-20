using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        // GET: api/Products
        [HttpGet]
        public List<Product> Get()
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                return db.Products.ToList();
            }
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                return db.Products.Where(p => p.ProductId == id).SingleOrDefault();
            }
        }

        // POST: api/Products
        [HttpPost]
        public void Post([FromBody]string value)
        {
            Product product = new Product
            {
                ProductName = value
            };

            using (NorthwindContext db = new NorthwindContext())
            {
                db.Entry(product).State = EntityState.Added;
                db.SaveChanges();
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                Product product = db.Products.SingleOrDefault(p => p.ProductId == id);
                if (product == null)
                    return;

                product.ProductName = value;

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (NorthwindContext db = new NorthwindContext())
            {
                Product product = db.Products.SingleOrDefault(p => p.ProductId == id);
                if (product == null)
                    return;

                db.Entry(product).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
