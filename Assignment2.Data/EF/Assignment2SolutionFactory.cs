using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Assignment2.Data.EF
{
    public class Assignment2SolutionFactory : IDesignTimeDbContextFactory<Assignment2DbContext>
    {
        public Assignment2DbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot root = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsetting.json").Build();

            var connectString = root.GetConnectionString("Assignment2");
            var optionBuilder = new DbContextOptionsBuilder<Assignment2DbContext>();
            optionBuilder.UseSqlServer(connectString);
            return new Assignment2DbContext(optionBuilder.Options);
        }
    }
}
