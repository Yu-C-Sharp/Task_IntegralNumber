using System;
using System.Collections.Generic;
using static System.Console;
using Methods;

namespace Task_IntegralNumber
{
    class Program
    {  
        static void Main(string[] args)
        {
            string input;
            int Input;
            List<int> Result = new List<int>();
            while(true)
            {
                Write("Enter a positive integral number...");
                input = ReadLine();
                if (Sources.ExceptionInput(input)) break;
                else WriteLine("Come on! Let's try again...");
            }
            Input = Convert.ToInt32(input);
            Sources.Squaring(Input, Result);
            Sources.ShowResult(Result);
            ReadKey();
        }
    }
}