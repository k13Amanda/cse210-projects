// I added a choice of 3 sriptures to choose from to memorize.
// I added a message when all words are hidden and you can then quit on enter.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        var scriptures = new Dictionary<int, (Reference reference, string text)>
        {
            { 1, (new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.") },
            { 2, (new Reference("Psalm", 23, 1, 2), "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: he leadeth me beside the still waters.") },
            { 3, (new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.") }
        };

        Console.WriteLine("Choose a scripture to memorize:");
        Console.WriteLine("1. John 3:16");
        Console.WriteLine("2. Psalm 23:1-2");
        Console.WriteLine("3. Proverbs 3:5-6");


        int choice = 0;
        while (choice < 1 || choice > 3)
        {
            Console.Write("Enter the number of your choice: ");
            choice = int.Parse(Console.ReadLine());
        }

        var selectedScripture = scriptures[choice];

        Scripture scripture = new Scripture(selectedScripture.reference, selectedScripture.text);

        string userEntry = "";

        // Main loop
        while (userEntry != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");

            userEntry = Console.ReadLine();

            if (userEntry != "quit")
            {
                scripture.HideRandomWords(3); 
            }
        }
        
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("All words are hidden. Press enter to finish.");
            Console.ReadLine();
        }
    }
}
