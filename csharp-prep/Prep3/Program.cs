using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);

        int guess = -1;

        while (guess != number)
       {
            Console.Write ("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (number == guess)
            {
                Console.WriteLine("That is correct!");
            }
            else
            {
                Console.WriteLine("That is not the number.");
                if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
            }
        }
           
    }   
}
