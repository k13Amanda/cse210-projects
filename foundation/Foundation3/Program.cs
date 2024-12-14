using System;

class Program
{
    static void Main(string[] args)
    {
        DateTime runDate = new DateTime(2022, 11, 03);
        Running run = new Running(runDate, "Running", 30, 3);
        Console.WriteLine(run.GetSummary());


   
        DateTime swimDate = new DateTime(2024, 10, 23);
        Swimming swim = new Swimming(swimDate, "Swimming", 45, 20);
        Console.WriteLine(swim.GetSummary());



        DateTime cycleDate = new DateTime(2024, 09, 15);
        Cycling cycling = new Cycling(cycleDate, "Cycling", 60, 15);
        Console.WriteLine(cycling.GetSummary());

    }

}
