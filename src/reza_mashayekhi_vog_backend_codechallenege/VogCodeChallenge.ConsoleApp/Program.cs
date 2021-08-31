using System;
using System.Linq;

namespace VogCodeChallenge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestionClass.NamesList.Select(n => { Console.WriteLine(n); return n; }).ToList();
        }
    }
}
