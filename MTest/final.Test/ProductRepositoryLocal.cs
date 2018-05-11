using System.Collections.Generic;
using final.Models;

namespace final.Test
{
    public class ProductRepositoryLocal : IProjectsRepository
    {
        public IEnumerable<Product> GetAll()
        {
            var result = new List<Product>();

            result.Add(new Product(){ Id = 1, Category_id = 1,  fromPoint = "Almaty", toPoint = "Semey", seatNumber = 32 });
            result.Add(new Product(){ Id = 2, Category_id = 2,  fromPoint = "Karagandy", toPoint = "Astana", seatNumber = 17 });
            result.Add(new Product(){ Id = 3, Category_id = 3,  fromPoint = "Oskemen", toPoint = "Oral", seatNumber = 23 });
            result.Add(new Product(){ Id = 4, Category_id = 2,  fromPoint = "Semey", toPoint = "Aktau", seatNumber = 4 });
            IEnumerable<Product> pr = result;
            return pr;
        }
         public void Delete(int id){

         }
          public Product Post(Product value)
          {
             Product p = new Product();
             return p;
          }
           public void Put(int id, Product value)
           {
           }

    }
}