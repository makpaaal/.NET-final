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
    public class MasterController : Controller
    {
        private DateContext _context;

        public MasterController(DateContext context)
        {
           _context = context;
        }

        [HttpGet]
        public IEnumerable<Master> Get()
        {
            var masters = _context.MasterTable.AsQueryable();
            return masters; 
        }


        [HttpPost]
        public void Post([FromBody] Master mast)
        {
            var masters = _context.MasterTable;
            mast.Master_id = masters.Max(x => x.Master_id) +1;
            masters.Add(mast);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var masters = _context.MasterTable;
            var item = masters.First(x => x.Master_id == id);
            masters.Remove(item);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put([FromBody] Master mast)
        {
                var masters = _context.MasterTable;
                var existingMaster = masters.Where(s => s.Master_id == mast.Master_id)
                                                        .FirstOrDefault<Master>();

                    existingMaster.Customer = mast.Customer;
                    existingMaster.Detail = mast.Detail;
            
            
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