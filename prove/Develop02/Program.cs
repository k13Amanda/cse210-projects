// I checked to make sure its a valid file and use if else statement to let the user know.
// I added a message to track the daily streaks and display it afrer they save a new entry. 
// this should give motovation to write everyday and show them progress. 

using System;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string menuSelection = "";

        // Main loop to display the menu and process user input.
        while (menuSelection != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            menuSelection = Console.ReadLine();

            if (menuSelection == "1")
            {
                // Read prompts from the file and select one randomly.
                var prompts = new List<string>(File.ReadAllLines("prompts.txt"));
                var randomWord = new Random();
                var index = randomWord.Next(prompts.Count);
                var selectedPrompt = prompts[index];
                Console.WriteLine(selectedPrompt);
                var newEntry = Console.ReadLine();
                journal.AddEntry(selectedPrompt, newEntry);
            }
            else if (menuSelection == "2")
            {
                journal.DisplayEntries();
            }
            else if (menuSelection == "3")
            {
                Console.Write("What file do you want to load? ");
                var filePath = Console.ReadLine();
                journal.LoadFile(filePath);
            }
            else if (menuSelection == "4")
            {
                journal.SaveEntries();
            }
        }
    }
}
