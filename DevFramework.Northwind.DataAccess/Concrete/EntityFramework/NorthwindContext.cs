﻿using DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
            Database.SetInitializer<NorthwindContext>(null);
        }

        public DbSet<Product> Products { get; set; }
        // Normal şartlarda mapping otomatik yapılır. <Product> --> Products tablosune bağlar. Ama defensive programming yapmak lazım. Bu nedenle mappingi elle yaparsak mükemmel olur. 

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
        }
    }
}
