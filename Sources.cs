using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Methods
{
    static class Sources
    {
        public static bool ExceptionInput(string x)
        {
            try
            {
                int z = Convert.ToInt32(x);
                if (z > 46343) throw new Exception($"The number - \"{x}\" - is out of range");
                if (z > 0) return true;
                else throw new Exception($"The number - \"{x}\" - is not positive number...");
            }
            catch (FormatException) { WriteLine($"Symbol(s) -  \"{x}\" - is not integral number..."); }
            catch (Exception ex) { WriteLine($"{ex.Message}"); }
            return false;
        }
        public static void Squaring(int Input, List<int> Result)
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
                    if (j - 1 == 0 && Result[1] > 1)
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
        public static void ShowResult(List<int> Result)
        {
            Result.Reverse();
            Write("Solution : [");
            foreach (int item in Result)
            {
                if (item == Result[Result.Count - 1]) Write(item);
                else Write(item + ",");
            }
            Write("]\n");
        }
    }
}
