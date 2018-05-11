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
    public class DetailController : Controller
    {
        private DateContext _context;

        public DetailController(DateContext context)
        {
           _context = context;
        }

        [HttpGet]
        public IEnumerable<Detail> Get()
        {
            var details = _context.DetailTable.AsQueryable();
            return details; 
        }


        [HttpPost]
        public void Post([FromBody] Detail det)
        {
            var details = _context.DetailTable;
            det.Detail_id = details.Max(x => x.Detail_id) +1;
            details.Add(det);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var details = _context.DetailTable;
            var item = details.First(x => x.Detail_id == id);
            details.Remove(item);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] Detail det)
        {
                var details = _context.DetailTable;
                var existingDetail = details.Where(s => s.Detail_id == det.Detail_id)
                                                        .FirstOrDefault<Detail>();

                    existingDetail.Products = det.Products;
                    existingDetail.Master = det.Master;
                    existingDetail.Price = det.Price;
                    existingDetail.dateOfFlight = det.dateOfFlight;
            
            
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