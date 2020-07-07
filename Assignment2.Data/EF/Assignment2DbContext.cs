using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Assignment2.Data.Entities;
using Assignment2.Data.Configurations;

namespace Assignment2.Data.EF
{
    public class Assignment2DbContext : IdentityDbContext
    {
        public Assignment2DbContext(DbContextOptions db) : base(db)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
