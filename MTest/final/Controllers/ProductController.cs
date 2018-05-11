using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using final.Models;

namespace final.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private DateContext _context;

        public ProductController(DateContext context)
        {
           _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = _context.ProductTable.AsQueryable();
            return products; 
        }


        [HttpPost]
        public void Post([FromBody] Product prod)
        {
            var products = _context.ProductTable;
            prod.Product_id = products.Max(x => x.Product_id) +1;
            products.Add(prod);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var products = _context.ProductTable;
            var item = products.First(x => x.Product_id == id);
            products.Remove(item);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] Product det)
        {
                var products = _context.ProductTable;
                var existingProduct = products.Where(s => s.Product_id == det.Product_id)
                                                        .FirstOrDefault<Product>();

                    existingProduct.Category = det.Category;
                    existingProduct.fromPoint = det.fromPoint;
                    existingProduct.toPoint = det.toPoint;
                    existingProduct.seatNumber = det.seatNumber;
            
            
        }

        [HttpPatch]
        public void Patch([FromBody] Product cust)
        {
            var products = _context.ProductTable;
            var existingProduct = products.Where(s => s.Product_id == cust.Product_id)
                                                       .FirstOrDefault<Product>();
            
           if (cust.Category != null) existingProduct.Category = cust.Category;
           if(cust.fromPoint != null) existingProduct.fromPoint =cust.fromPoint;
           if(cust.toPoint != null)  existingProduct.toPoint = cust.toPoint;
           if(cust.seatNumber <=0) existingProduct.seatNumber =cust.seatNumber;
        }
    }
}