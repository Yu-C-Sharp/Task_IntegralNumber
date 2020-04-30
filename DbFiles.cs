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
    static class DbMethodes
    {
        public static void LoadToDb(Number obj)
        {
            DbContextOptions<ApplicationContext> options = CreateOptions.JSON_FILE_Configuration();
            using (ApplicationContext db = new ApplicationContext(options))
            {
                db.Add(obj);
                db.SaveChanges();
            }
        }
        public static void StartInitDb()
        {
            DbContextOptions<ApplicationContext> options = CreateOptions.JSON_FILE_Configuration();
            using (ApplicationContext db = new ApplicationContext(options))
            {
                Number Temp = db.Numbers.FirstOrDefault();
                if (Temp == null)
                {
                    Number First = new Number() { Num = 1, Result = "No Solution" };
                    Number Second = new Number() { Num = 2, Result = "No Solution" };
                    Number Third = new Number() { Num = 3, Result = "No Solution" };
                    db.AddRange(First, Second, Third);
                    db.SaveChanges();
                }
            }
        }
        public static void UploadFromDbLastFiveResults()
        {
            DbContextOptions<ApplicationContext> options = CreateOptions.JSON_FILE_Configuration();
            using (ApplicationContext db = new ApplicationContext(options))
            {
                List<Number> number = db.Numbers.ToList();
                WriteLine("The last five results of the program :");
                for (int i = 0, j = 1; i < 5; ++i, ++j)
                {
                    if (number.Count() - j >= 0) WriteLine($"Number - {number[number.Count() - j].Num} : Solution - [{number[number.Count() - j].Result}]");
                    else
                    {
                        WriteLine("There are no more results in Database...");
                        break;
                    }
                }
            }
        }
    }
}
