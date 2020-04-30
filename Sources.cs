using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using IntegralNumber;

namespace Methodes
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
        public static void Squaring(Number obj, List<int>Temp)
        {
            if (obj.Num < 5)
            {
                WriteLine("No solution...");
                obj.Result = "No Solution";
                return;
            }          
            int input_square;
            for (int i = obj.Num - 1; i > 0; --i)
            {
                Temp.Clear();
                input_square = (int)(Math.Pow(obj.Num, 2) - Math.Pow(i, 2));
                Temp.Add(i);
                for (int j = i - 1; j > 0; --j)
                {

                    if (input_square - j * j > 0)
                    {
                        input_square -= j * j;
                        Temp.Add(j);
                    }
                    else if (input_square - j * j == 0)
                    {
                        Temp.Add(j);
                        Temp.Reverse();
                        foreach(int item in Temp)
                        {
                            if (item == Temp[Temp.Count - 1]) obj.Result += item.ToString();
                            else obj.Result += item.ToString() + ",";
                        }
                        return;
                    }
                    if (j - 1 == 0 && Temp[1] > 1)
                    {
                        j = Temp[1];
                        Temp.Clear();
                        Temp.Add(i);
                        input_square = (int)(Math.Pow(obj.Num, 2) - Math.Pow(i, 2));
                    }
                    else continue;
                }
            }
            WriteLine("No solution...");
            obj.Result = "No Solution";
            Temp.Clear();
        }
        public static void ShowResult(List<int>Temp)
        {
            Write("Solution : [");
            foreach (int item in Temp)
            {
                if (item == Temp[Temp.Count - 1]) Write(item);
                else Write(item + ",");
            }
            Write("]\n");
        }
       
    }
}
