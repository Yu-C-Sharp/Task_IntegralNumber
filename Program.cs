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
            DbMethodes.StartInitDb();
            DbMethodes.UploadFromDbLastFiveResults();
            string input;
            List<int> Temp = new List<int>();
            while (true)
            {
                Write("Enter a positive integral number...");
                input = ReadLine();
                if (Sources.ExceptionInput(input)) break;
                else WriteLine("Come on! Let's try again...");
            }
            Number Input = new Number() { Num = Convert.ToInt32(input) };
            Sources.Squaring(Input, Temp);
            DbMethodes.LoadToDb(Input);
            Sources.ShowResult(Temp);
            ReadKey();
        }
    }
}