
using System;
using System.Collections.Generic;
using System.IO;

// This class manages the collection of journal entries.
public class Journal
{
    // List to store new entries.
    public List<Entry> Entries { get; private set; } = new List<Entry>();

    // List to store loaded entries from a file.
    public List<Entry> LoadedEntries { get; private set; } = new List<Entry>();

    // Variable to store the name of the user file.
    public string UserFile { get; private set; } = "";

    // Method to add a new entry to the journal.
    public void AddEntry(string prompt, string content)
    {
        Entries.Add(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, content));
    }

    // Method to load journal entries from a file.
    public void LoadFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            UserFile = filePath;
            Entries.Clear();
            LoadedEntries.Clear();

            // Read all lines from the file and process them.
            var fileContents = File.ReadAllLines(filePath);
            for (int i = 0; i < fileContents.Length; i += 3)
            {
                if (i + 2 < fileContents.Length)
                {
                    string dateLine = fileContents[i];
                    string contentLine = fileContents[i + 1];
                    string blankLine = fileContents[i + 2];
                    if (dateLine.StartsWith("Date: ") && dateLine.Contains(" - Prompt: ") && contentLine.StartsWith("Entry: "))
                    {
                        string date = dateLine.Substring(6, 10);
                        string prompt = dateLine.Substring(20);
                        string content = contentLine.Substring(7);
                        LoadedEntries.Add(new Entry(date, prompt, content));
                    }
                }
            }
            Console.WriteLine($"File {UserFile} loaded successfully.");
        }
        else
        {
            Console.WriteLine("That file does not exist.");
        }
    }

    // Method to save new entries to the user file.
    public void SaveEntries()
    {
        if (string.IsNullOrEmpty(UserFile))
        {
            Console.Write("Enter the file name to save entries: ");
            UserFile = Console.ReadLine();
        }

        if (!string.IsNullOrEmpty(UserFile))
        {
            using (StreamWriter sw = new StreamWriter(UserFile, true))
            {
                foreach (var entry in Entries)
                {
                    sw.WriteLine(entry.ToString());
                    sw.WriteLine(); // Add a blank line between entries
                }
            }
            Console.WriteLine("Entries saved successfully.");
            Entries.Clear();
        }
        else
        {
            Console.WriteLine("Invalid file name. Please try again.");
        }
    }

    // Method to display both loaded and new entries.
    public void DisplayEntries()
    {
        if (LoadedEntries.Count > 0)
        {
            Console.WriteLine("Existing Entries:");
            foreach (var entry in LoadedEntries)
            {
                Console.WriteLine(entry.ToString());
                Console.WriteLine(); // Add a blank line between entries
            }
        }

        if (Entries.Count > 0)
        {
            Console.WriteLine("New Entries:");
            foreach (var entry in Entries)
            {
                Console.WriteLine(entry.ToString());
                Console.WriteLine(); // Add a blank line between entries
            }
        }
    }
}
