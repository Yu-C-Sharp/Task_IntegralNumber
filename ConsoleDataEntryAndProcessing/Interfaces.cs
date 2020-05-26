using System;
using ClassLibraryNumber;

namespace ConsoleDataEntryAndProcessing
{
    public interface IInputData
    {
        string GetInputData();
    }
    public interface IValidator
    {
        bool Check(string input);
    }
    public interface ICompute
    {
        void Squaring(Number number);
    }
    public interface IShow
    {
        void Show(Number number);
    }
}
