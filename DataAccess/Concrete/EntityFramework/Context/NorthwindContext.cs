using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class NorthwindContext:DbContext 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\ProjectModels;Database=Northwind;Trusted_Connection=true");
                //connectionString veri tabanina erisim bilgisi
                public DbSet<Product> Products { get; set; }
        }
    }
}
