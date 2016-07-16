using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestBalticSoft
{
    public class mDbContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public mDbContext() : base("name=TestBaltikSoft")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder context)
        {
            context.Entity<Order>().ToTable("Orders");
            context.Entity<Person>().ToTable("Persons");
            context.Entity<Organization>().ToTable("Organizations");
            base.OnModelCreating(context);
        }

    }
}
