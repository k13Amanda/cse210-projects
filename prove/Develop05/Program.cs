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
                Activity activity = new BreathingActivity();
                activity.DisplayStartingMessage();
                activity.DisplayEndingMessage();
            }

            else if (menuSelection == 2)
            {
              Activity activity = new ReflectingActivity();
                activity.DisplayStartingMessage();
                activity.DisplayEndingMessage();  
            }

            else if (menuSelection == 3)
            {
                Activity activity = new ListingActivity();
                activity.DisplayStartingMessage();
                activity.DisplayEndingMessage();
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
