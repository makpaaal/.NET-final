using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final.Models
{
    public class Customer
    {
    [Key]
    public int Customer_id { get; set; }
    public string Customer_name { get; set; }
    
    [ForeignKey("Master_id")] 
    public ICollection<Master> Masters { get; set; } 
    }
}
