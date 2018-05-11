using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using final.Models;
using final.Controllers;

namespace final.Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void CheckRepository()
        {
            var repository = new ProductRepositoryLocal();
            var manager = new ProductManager(repository);
        
            var data = manager.Get() as List<Product>;    
            Assert.IsNotNull(data);            
        }
        [TestMethod]
        public void CorrectProductValidationc()
        {
             var repository = new ProductRepositoryLocal();
             DateTime date1 = new DateTime(2010, 8, 18);
             DateTime date2 = new DateTime(2011, 8, 18);
             Product p = new Product() {
                 Id = 1, Category_id = 3,  fromPoint = "Almaty", toPoint = "Atyrau", seatNumber = 25
            };  
             var manager = new ProductManager(repository);
       
             bool val = manager.Validate(p);   
            Assert.AreEqual(val, true);
             

        }
        [TestMethod]
        public void InCorrectProductValidationc()
        {
             var repository = new ProductRepositoryLocal();
             DateTime date1 = new DateTime(2010, 8, 12);
             DateTime date2 = new DateTime(2011, 8, 18);
             Product p = new Product() {
                 Id = 10, Category_id = 2,  fromPoint = "Semey", toPoint = "Semey", seatNumber = 45
            };  
             var manager = new ProductManager(repository);
       
             bool val = manager.Validate(p);   
             Assert.AreEqual(val, false);
             

        }
        [TestMethod]
        public void InCorrrrectProductValidationc()
        {
             var repository = new ProductRepositoryLocal();
             DateTime date1 = new DateTime(2010, 8, 12);
             DateTime date2 = new DateTime(2011, 8, 18);
             Product p = new Product() {
                 Id = 10, Category_id = 2,  fromPoint = "Aktobe", toPoint = "Semey", seatNumber = -200
            };  
             var manager = new ProductManager(repository);
       
             bool val = manager.Validate(p);   
             Assert.AreEqual(val, false);
             

        }

    }
}
