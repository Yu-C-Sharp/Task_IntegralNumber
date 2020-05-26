using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ClassLibraryNumber;

namespace DatabaseConnection
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Number> Numbers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)

        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Number>().HasData(
                new Number[]
                {
                new Number { NumberID=1, Num = 1, Result = "No Solution"},
                new Number { NumberID=2, Num = 2, Result = "No Solution"},
                new Number { NumberID=3, Num = 3, Result = "No Solution"}
                });
        }
    }
}

