using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IntegralNumber;
using Methodes;

namespace Database
{
    class ApplicationContext : DbContext
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
    static class CreateOptions
    {
        public static DbContextOptions<ApplicationContext> JSON_FILE_Configuration()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            DbContextOptions<ApplicationContext> options = optionsBuilder.UseSqlServer(connectionString).Options;
            return options;
        }
    }
    class DbMethodes
    {
        public void LoadToDb(Number obj)
        {
            DbContextOptions<ApplicationContext> options = CreateOptions.JSON_FILE_Configuration();
            using (ApplicationContext db = new ApplicationContext(options))
            {
                db.Add(obj);
                db.SaveChanges();
            }
        }
        public void UploadFromDbLastFiveResults()
        {
            DbContextOptions<ApplicationContext> options = CreateOptions.JSON_FILE_Configuration();
            using (ApplicationContext db = new ApplicationContext(options))
            {
                /////   Teacher's Solution
               /* var lastFiveResult = db.Numbers.OrderBy(b => b.NumberID).Skip(Math.Max(0, db.Numbers.OrderBy(b => b.NumberID).Count() - 5));
                WriteLine("The last five results of the program :");
                foreach (Number item in lastFiveResult)
                    WriteLine($"Id - {item.NumberID} :: Number - {item.Num} : Solution - [{item.Result}]");
                if (lastFiveResult.Count() < 5) WriteLine("There are no more results in Database...");*/

                  ///// My Solution
                IEnumerable<Number> query = from item in db.Numbers.OrderByDescending(key => key.NumberID)                                           
                                             where item.NumberID < 6
                                             select item;
                WriteLine("The last five results of the program :");
                foreach (Number item in query)
                    WriteLine($"Id - {item.NumberID} :: Number - {item.Num} : Solution - [{item.Result}]");
                if (query.Count() < 5) WriteLine("There are no more results in Database..."); 
            }
        }
    }
}
