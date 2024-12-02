using System;
using System.Linq.Expressions;
using System.Runtime;

class Program
{
    static void Main(string[] args)
    {
        Assignment h1 = new Assignment ("Amanda", "Math");
        Console.WriteLine(h1.GetSummary());

        MathAssignment h2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(h2.GetSummary());
        Console.WriteLine(h2.GetHomeworkList());

        WritingAssignment h3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(h3.GetSummary());
        Console.WriteLine(h3.GetWritingInformation());

    }
}