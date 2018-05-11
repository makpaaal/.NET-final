using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace final.Models 
{
    public class DateContext: DbContext {
    
        public virtual DbSet<Customer> CustomerTable {get; set;}
        public virtual DbSet<Master> MasterTable {get; set;}
        public virtual DbSet<Detail> DetailTable {get; set;}
        public virtual DbSet<Product> ProductTable {get; set;}
        public virtual DbSet<Category> CategoryTable {get; set;}

        public DateContext(DbContextOptions<DateContext> options) : base(options)
        {
        }

    }
}