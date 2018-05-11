
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final.Models
{
    public class Detail
    {
    [Key]
    public int Detail_id { get; set; }
    
    [ForeignKey("Product_id")] 
    public ICollection<Product> Products { get; set; } 
    
    [ForeignKey("Master_id")] 
    public  Master Master { get; set; } 
    
    public int Price { get; set; }
    public DateTime dateOfFlight {get; set;}
    }
}



