using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using IntegralNumber;

namespace Methodes
{
    interface IInputData
    {
        string GetInputData();
    }
    class ConsoleInput : IInputData
    {
        public string GetInputData()
        {
            Write("Enter a positive integral number...");
            string input = ReadLine();
            return input;

        }
    }
    interface IValidator
    {
        bool Check(string input);
    }
    class ControlInput : IValidator
    {
        public bool Check(string input)
        {
            try
            {
                int z = Convert.ToInt32(input);
                if (z > 46343) throw new Exception($"The number - \"{input}\" - is out of range");
                if (z > 0) return true;
                else throw new Exception($"The number - \"{input}\" - is not positive number...");
            }
            catch (FormatException) { WriteLine($"Symbol(s) -  \"{input}\" - is not integral number..."); }
            catch (Exception ex) { WriteLine($"{ex.Message}"); }
            return false;
        }
    }
    interface ICompute
    {
        void Squaring(Number number);
    }
    class Calculate : ICompute
    {
        public void Squaring(Number number)
        {
            List<int> Temp = new List<int>();
            if (number.Num < 5)
            {
                WriteLine("No solution...");
                number.Result = "No Solution";
                return;
            }
            int input_square;
            for (int i = number.Num - 1; i > 0; --i)
            {
                Temp.Clear();
                input_square = (int)(Math.Pow(number.Num, 2) - Math.Pow(i, 2));
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
                        foreach (int item in Temp)
                        {
                            if (item == Temp[Temp.Count - 1]) number.Result += item.ToString();
                            else number.Result += item.ToString() + ",";
                        }
                        return;
                    }
                    if (j - 1 == 0 && Temp[1] > 1)
                    {
                        j = Temp[1];
                        Temp.Clear();
                        Temp.Add(i);
                        input_square = (int)(Math.Pow(number.Num, 2) - Math.Pow(i, 2));
                    }
                    else continue;
                }
            }
            WriteLine("No solution...");
            number.Result = "No Solution";
            Temp.Clear();
        }
    }
    interface IShow
    {
        void Show(Number number);
    }
    class Result : IShow
    {
        public void Show(Number number)
        {
            WriteLine($"Number - {number.Num} : Solution - [{number.Result}]");
        }
    }
    class Compute
    {
        public IInputData Inputter { get; set; }
        public IValidator Checker { get; set; }
        public ICompute Calculator { get; set; }
        public IShow Showing { get; set; }
        public Compute(IInputData inputter, IValidator checker, ICompute calculator, IShow showing)
        {
            Inputter = inputter;
            Checker = checker;
            Calculator = calculator;
            Showing = showing;
        }
        public Number ProgramWork()
        {
            while (true)
            {
                string input = Inputter.GetInputData();
                if (Checker.Check(input))
                {
                    Number Input = new Number() { Num = Convert.ToInt32(input) };
                    Calculator.Squaring(Input);
                    Showing.Show(Input);
                    return Input;
                }
                else
                    WriteLine("Come on! Let's try again...");
            }
        }
    }
}
