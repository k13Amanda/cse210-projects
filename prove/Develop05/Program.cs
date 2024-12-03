using System;

class Program
{
    static void Main(string[] args)
    {
        int menuSelection = 0;

        while (menuSelection != 4)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Opportunities");
            Console.WriteLine("What mindfulness opportunity would you like to do?");
            Console.WriteLine("Menu Options:\n   1. Start breathing activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. Quit\nSelect a choice from the menu:");

            string input = Console.ReadLine();
            
            if (int.TryParse(input, out menuSelection))
            {
                Activity activity = null;

                if (menuSelection == 1)
                {
                    activity = new BreathingActivity();
                }
                else if (menuSelection == 2)
                {
                    activity = new ReflectingActivity();
                }
                else if (menuSelection == 3)
                {
                    activity = new ListingActivity();
                }
                else if (menuSelection == 4)
                {
                    Console.WriteLine("Quit");
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid input. Please select a valid option.");
                    continue; 
                }

                activity.Run();

                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }
        }
    }
}
