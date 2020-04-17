using System;
using System.Collections.Generic;
using static System.Console;

namespace Task_IntegralNumber
{
    class Program
    {
        static bool ExceptionInput(string x)
        {
            try
            {
                int z = Convert.ToInt32(x);
                if (z > 46343) throw new Exception($"The number - \"{x}\" - is out of range");
                if (z > 0) return true;
                else throw new Exception ($"The number - \"{x}\" - is not positive number...");
            }
            catch (FormatException) { WriteLine($"Symbol(s) -  \"{x}\" - is not integral number..."); }
            catch (Exception ex) { WriteLine($"{ex.Message}"); }  
            return false;
        }
        static void Squaring(int Input, List<int> Result)
        {
            if (Input < 5)
            {
                WriteLine("No solution...");
                return;
            }
            int input_square;
            for (int i = Input - 1; i > 0; --i)
            {
                Result.Clear();
                input_square = (int)(Math.Pow(Input, 2) - Math.Pow(i, 2));
                Result.Add(i);
                for (int j = i - 1; j > 0; --j)
                {

                    if (input_square - j * j > 0)
                    {
                        input_square -= j * j;                   
                        Result.Add(j);
                    }
                    else if (input_square - j * j == 0)
                    {
                        Result.Add(j);
                        return;
                    }
                    if(j - 1 == 0 && Result[1] > 1)
                    {
                        j = Result[1];
                        Result.Clear();
                        Result.Add(i);
                        input_square = (int)(Math.Pow(Input, 2) - Math.Pow(i, 2));
                    }
                    else continue;
                }
            }
            WriteLine("No solution...");
            Result.Clear();
        }
        
        static void ShowResult(List<int>Result)
        {
            Result.Reverse();
            Write("Solution : ");
            Write("[");
            foreach (int item in Result)
            {
                if (item == Result[Result.Count - 1]) Write(item);
                else Write(item + ",");
            }
            Write($"]\n");
        }
        static void Main(string[] args)
        {
            string input;
            int Input;
            List<int> Result = new List<int>();
            while(true)
            {
                Write("Enter a positive integral number...");
                input = ReadLine();
                if (ExceptionInput(input)) break;
                else WriteLine("Come on! Let's try again...");
            }
            Input = Convert.ToInt32(input);
            Squaring(Input, Result);
            ShowResult(Result);
            ReadKey();
        }
    }
}