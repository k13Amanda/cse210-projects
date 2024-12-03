using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Mindfulness Opportunities");
        Console.WriteLine("What mindfulness opportunity would you like to do?");
        Console.WriteLine("Menu Options:\n   1. Start breathing activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. Quit\nSelect a choice from the menu:");

        // Read input from the console and parse it to an integer
        string input = Console.ReadLine();
        int menuSelection;
        
        if (int.TryParse(input, out menuSelection))
        {
            if (menuSelection == 1)
            {
                Console.WriteLine("Mindfulness Opportunities Breathing Activity");
                Console.WriteLine("Welcome to the Breathing Activity\n\nThis activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing. \nHow long, in seconds, would you like for your session?");
                input = Console.ReadLine();
                int breathingLength;
                if (int.TryParse(input, out breathingLength))
                {
                    Console.WriteLine($"You have selected a {breathingLength} second breathing session.");
                    // Here you can add the logic for the breathing activity
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            else if (menuSelection == 2)
            {
                Console.WriteLine("Mindfulness Opportunities Reflecting Activity");
                Console.WriteLine("Welcome to the Reflecting Activity\n\nThis activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.\nHow long, in seconds, would you like for your session?");
                input = Console.ReadLine();
                int reflectingLength;
                if (int.TryParse(input, out reflectingLength))
                {
                    Console.WriteLine($"You have selected a {reflectingLength} second reflecting session.");
                    // Here you can add the logic for the reflecting activity
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            else if (menuSelection == 3)
            {
                Console.WriteLine("Mindfulness Opportunities Listing Activity");
                Console.WriteLine("Welcome to the Listing Activity\n\nThis activity will help you reflect on good things in your life by having you list as many things as you can in a certain area.\nHow long, in seconds, would you like for your session?");
                input = Console.ReadLine();
                int listingLength;
                if (int.TryParse(input, out listingLength))
                {
                    Console.WriteLine($"You have selected a {listingLength} second listing session.");
                    // Here you can add the logic for the listing activity
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
            else if (menuSelection == 4)
            {
                Console.WriteLine("Quit");
            }
            else
            {
                Console.WriteLine("Invalid input. Please select a valid option.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }
}
