using System;
using System.Data;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradeInput = Console.ReadLine();
        int grade = int.Parse(gradeInput);
        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
            // Console.WriteLine("Your grade is A");
        }
         else if (grade >= 80)
        {
            // Console.WriteLine("Your grade is B");
            letter = "B";
        }

        else if (grade >= 70)
        {
            // Console.WriteLine("Your grade is C");
            letter = "C";
        }
        else if (grade >= 60)
        {
            // Console.WriteLine("Your grade is D");
            letter = "D";
        }
        
        else if (grade < 60)
        {
            // Console.WriteLine("Your grade is F");
            letter = "F";
        }
        
        Console.WriteLine($"Your grade is: {letter}."); 

        if (grade >=70)
        {
            Console.WriteLine("Congratulations you passed the calss!");
        }
        else
        {
            Console.Write("Better luck next time.");
        }  
  
    }
}