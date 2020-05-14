using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;
using Methodes;
using IntegralNumber;
using Database;


namespace Task_IntegralNumber
{
    class Program
    {  
        static void Main(string[] args)
        {
	        DbMethodes DbAction = new DbMethodes();
            DbAction.UploadFromDbLastFiveResults();
            Compute compute = new Compute(new ConsoleInput(), new ControlInput(), new Calculate(), new Result());
            DbAction.LoadToDb(compute.ProgramWork());
            ReadKey();
        }
    }
}