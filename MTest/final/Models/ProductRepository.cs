using System;
using System.Collections.Generic;
using System.Linq;

namespace lab8.Models
{
     public interface IProjectsRepository//dbinjection
    {
        IEnumerable<Product> GetAll();
        void Delete (int id);
        Product Post(Product value);
       void Put(int id, Product value);
    } 
    public class ProductRepository: IProjectsRepository
    {
        private ProductContext _context;
        
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
           var products = _context.Products.AsQueryable();
           return products;
        }
        public void Delete(int id){
            Product p = _context.Products.FirstOrDefault(x=>x.Product_id == id);
            _context.Remove(p);       
            _context.SaveChanges();
        }
         public Product Post(Product value)
        {
             _context.Products.Add(value);
             _context.SaveChanges();
             return value;
        }
         public void Put(int id, Product value)
        {
            Product curStud = _context.Products.FirstOrDefault(x => x.Product_id == id); // students.Where(x =>x.Id == id)
            curStud.Category_id = value.Category_id;
            curStud.fromPoint = value.fromPoint;
            curStud.toPoint = value.toPoint;
            curStud.seatNumber = value.seatNumber;
            
           // _context.Products.Update(curStud);
            _context.SaveChanges();
            
        }
    }
   
}