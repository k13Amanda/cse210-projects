using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {


        List <int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int enterList;

        do
        {   Console.Write("Enter Number: ");
            enterList = int.Parse(Console.ReadLine());
            if (enterList != 0)
            {
                numbers.Add(enterList);
            }
        } while (enterList != 0); 

        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}"); 

        if (numbers.Count > 0)
        {
            double average = (double)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");
        }

        int largestNumber = numbers.Max();
        Console.WriteLine($"The largest number is: {largestNumber}");
        
    }
}