using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final.Models
{
    public class Category
    {
    [Key]
    public int Category_id { get; set; }
    public string Category_name { get; set; }
    
    [ForeignKey("Product_id")] 
    public ICollection<Product> Products { get; set; } 
    }
}
