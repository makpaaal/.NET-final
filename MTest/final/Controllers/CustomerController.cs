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
    public class StudentController : Controller
    {
        private DateContext _context;

        public StudentController(DateContext context)
        {
           _context = context;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customers = _context.CustomerTable.AsQueryable();
            return customers ;
        }


        [HttpPost]
        public void Post([FromBody] Customer cust)
        {
            var customers = _context.CustomerTable;
            cust.Customer_id = customers.Max(x => x.Customer_id) +1;
            customers.Add(cust);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customers = _context.CustomerTable;
            var item = customers.First(x => x.Customer_id == id);
            customers.Remove(item);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] Customer cust)
        {
                var customers = _context.CustomerTable;
                var existingCustomer = customers.Where(s => s.Customer_id == cust.Customer_id)
                                                        .FirstOrDefault<Customer>();

                    existingCustomer.Customer_name = cust.Customer_name;
                    existingCustomer.Masters = cust.Masters;
            
            
        }

        [HttpPatch]
        public void Patch([FromBody] Customer cust)
        {
            var customers = _context.CustomerTable;
            var existingCustomer = customers.Where(s => s.Customer_id == cust.Customer_id)
                                                       .FirstOrDefault<Customer>();
            
           if (cust.Customer_name != null) existingCustomer.Customer_name = cust.Customer_name;
           if(cust.Masters != null) existingCustomer.Masters =cust.Masters;
        }
    }
}