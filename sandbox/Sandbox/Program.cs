using System;

class Program
{
    static void Main(string[] args)
    {
        string menuSelection ="";
        while (menuSelection != "5")
        {
            Console.WriteLine("Please select one of the following choices.");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");
            menuSelection = Console.ReadLine();

            if (menuSelection == "1")
            {
                List<string> prompts = new List<string>(File.ReadAllLines("prompts.txt"));

            }
              else if (menuSelection == "2")
            {

            }
              else if (menuSelection == "3")
            {

            }
              else if (menuSelection == "4")
            {

            }
        }
    }
}

