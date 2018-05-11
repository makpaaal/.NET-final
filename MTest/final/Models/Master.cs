
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final.Models
{
    public class Master
    {
    [Key]
    public int Master_id { get; set; }
    
    [ForeignKey("Customer_id")] 
    public Customer Customer { get; set; } 
    
    [ForeignKey("Detail_id")] 
    public Detail Detail { get; set; } 
    }

}



