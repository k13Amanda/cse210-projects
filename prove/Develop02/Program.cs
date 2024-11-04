using System;
// using System.Runtime.CompilerServices;
// using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> entries = new List<string>();
    static string userFile = "";

    static void Main(string[] args)
    {
        string menuSelection = "";

        while (menuSelection != "5")
        {
            Console.WriteLine("Please select one of the following choices.");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            menuSelection = Console.ReadLine();

            if (menuSelection == "1")
            {
                List<string> prompts = new List<string>(File.ReadAllLines("prompts.txt"));
                Random randomWord = new Random();
                int index = randomWord.Next(prompts.Count);
                string selectedPrompt = prompts[index];
                Console.WriteLine(selectedPrompt);
                string newEntry = Console.ReadLine();
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                entries.Add($"Date: {date} - Prompt: {selectedPrompt}\nEntry: {newEntry}");
            }
            else if (menuSelection == "2")
            {
                Console.WriteLine("Displaying Entries:");
                foreach (string entry in entries)
                {
                    Console.WriteLine(entry);
                }
            }
            else if (menuSelection == "3")
            {
                Console.Write("What file do you want to load? ");
                userFile = Console.ReadLine();

                if (File.Exists(userFile))
                {
                    entries = new List<string>(File.ReadAllLines(userFile));
                    Console.WriteLine($"File {userFile} loaded successfully.");
                }
                else
                {
                    Console.WriteLine("That file does not exist.");
                }
            }
            else if (menuSelection == "4")
            {
                if (string.IsNullOrEmpty(userFile))
                {
                    Console.Write("Enter the file name to save entries: ");
                    userFile = Console.ReadLine();
                }

                if (!string.IsNullOrEmpty(userFile))
                {
                    File.AppendAllLines(userFile, entries);
                    Console.WriteLine("Entries saved successfully.");
                    entries.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid file name. Please try again.");
                }
            }
        }
    }
}
