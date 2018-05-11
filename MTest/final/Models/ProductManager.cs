using System;
using System.Collections.Generic;
using System.Linq;

namespace final.Models
{
    public interface IProjectsManager
    {
          IEnumerable<Product> GetAll();
          void Delete (int id);
          Product Post(Product value);
          void Put(int id, Product value);
    }

    public class ProductManager: IProjectsManager
    {
        private readonly IProjectsRepository _projectsRepository; 
        public ProductManager(IProjectsRepository projectsRepository)
        {
          _projectsRepository = projectsRepository;
        }
        
        public IEnumerable<Product> Get(){
            return  _projectsRepository.GetAll();
        }
         public Product GetId(int id){

            var values =  _projectsRepository.GetAll();
            Product p = values.FirstOrDefault(x=>x.Product_id == id);
            return p;
        }
        public IEnumerable<Product> GetAll()
        {
            return _projectsRepository.GetAll();
        }
        public void Delete(int id)
         {
            _projectsRepository.Delete(id);
         }

         public Product Post(Product value)
         {
             Product val =  _projectsRepository.Post(value);
             return val;
         }

          public void Put(int id, Product value)
         {
             bool flag = Validate(value);
             if(flag == true){
                 _projectsRepository.Put(id,value);
             }
           
             
         }
         public bool Validate(Product value){
             bool flag;
             if(value.seatNumber>0 &&
                value.fromPoint != "" &&
                value.toPoint != "" &&
                value.category_id != "" && 
                value.fromPoint != value.toPoint ){
                flag = true;
             }else{
                 flag = false;
             }  
            return flag;
         }
    }
    
}