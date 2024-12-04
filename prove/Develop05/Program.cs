using System;

class Program
{
    static void Main(string[] args)
    {
        int menuSelection = 0;

        while (menuSelection != 5)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Opportunities");
            Console.WriteLine("Menu Options:\n   1. Start breathing activity\n   2. Start reflecting activity\n   3. Start listing activity\n   4. Start stretching activity\n   5. Quit\nSelect a choice from the menu:");

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
                    activity = new StretchingActivity();
                }
                else if (menuSelection == 5)
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

