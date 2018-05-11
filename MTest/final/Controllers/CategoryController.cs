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
    public class CategoryController : Controller
    {
        private DateContext _context;

        public CategoryController(DateContext context)
        {
           _context = context;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var categories = _context.CategoryTable.AsQueryable();
            return categories; 
        }


        [HttpPost]
        public void Post([FromBody] Category prod)
        {
            var categories = _context.CategoryTable;
            prod.Category_id = categories.Max(x => x.Category_id) +1;
            categories.Add(prod);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var categories = _context.CategoryTable;
            var item = categories.First(x => x.Category_id == id);
            categories.Remove(item);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] Category det)
        {
                var categories = _context.CategoryTable;
                var existingCategory = categories.Where(s => s.Category_id == det.Category_id)
                                                        .FirstOrDefault<Category>();

                    existingCategory.Category_name = det.Category_name;
            
            
        }

        [HttpPatch]
        public void Patch([FromBody] Category cust)
        {
            var categories = _context.CategoryTable;
            var existingCategory = categories.Where(s => s.Category_id == cust.Category_id)
                                                       .FirstOrDefault<Category>();
            
           if (cust.Category_name != null) existingCategory.Category_name= cust.Category_name;
        }
    }
}