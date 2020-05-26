using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using ClassLibraryNumber;
using ConsoleDataEntryAndProcessing;

namespace Task_IntegralNumber
{
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
