
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final.Models
{
    public class Product
    {
    [Key]
    public int Product_id { get; set; }
    
    [ForeignKey("Category_id")] 
    public Category Category { get; set; }     

    public string fromPoint { get; set; }
    public string toPoint {get; set;}
    public int seatNumber {get; set;}
    }
}



