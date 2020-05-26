using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ClassLibraryNumber;

namespace DatabaseConnection
{
    public class DbMethodes
    {
        public void LoadToDb(Number obj)
        {
            using (ApplicationContext db = new ApplicationContext(CreateOptions.JSON_FILE_Configuration()))
            {
                db.Add(obj);
                db.SaveChanges();
            }
        }
        public void UploadFromDbLastFiveResults()
        {
            using (ApplicationContext db = new ApplicationContext(CreateOptions.JSON_FILE_Configuration()))
            {
                /////   Teacher's Solution
                /* 
                 var lastFiveResult = db.Numbers.OrderBy(b => b.NumberID).Skip(Math.Max(0, db.Numbers.OrderBy(b => b.NumberID).Count() - 5));
                 WriteLine("The last five results of the program :");
                 foreach (Number item in lastFiveResult)
                     WriteLine($"Id - {item.NumberID} :: Number - {item.Num} : Solution - [{item.Result}]");
                 if (lastFiveResult.Count() < 5) WriteLine("There are no more results in Database...");
                 */

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
