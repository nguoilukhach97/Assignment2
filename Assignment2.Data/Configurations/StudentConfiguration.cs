using Assignment2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x=>x.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Name).HasMaxLength(250).IsRequired();
            builder.Property(p => p.YearOfBirth).IsRequired().HasDefaultValueSql("0");
            builder.Property(p => p.PhoneNumber).HasMaxLength(12).IsRequired();
            builder.HasOne(p => p.Address).WithMany(p => p.Students).HasForeignKey(p=>p.IdAdress);

            
        }
    }
}
