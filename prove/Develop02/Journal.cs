 
using System;
using System.Collections.Generic;
using System.IO;


// This class manages the collection of journal entries.
public class Journal
{
    // List to store new entries.
    private List<Entry> _entries = new List<Entry>();

    // List to store loaded entries from a file.
    private List<Entry> _loadedEntries = new List<Entry>();

    // Variable to store the name of the user file.
    private string _userFile = "";

    // Variable to track the daily entry streak.
    private int _entryStreak = 0;

    // Variable to track the date of the last entry saved.
    private DateTime _lastEntryDate;

    // Method to add a new entry to the journal.
    public void AddEntry(string prompt, string content)
    {
        _entries.Add(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, content));
    }

    // Method to load journal entries from a file.
    public void LoadFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            _userFile = filePath;
            _entries.Clear();
            _loadedEntries.Clear();

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
                        _loadedEntries.Add(new Entry(date, prompt, content));
                    }
                }
            }
            Console.WriteLine($"File {_userFile} loaded successfully.");
        }
        else
        {
            Console.WriteLine("That file does not exist.");
        }
    }

    // Method to save new entries to the user file and update the streak.
    public void SaveEntries()
    {
        if (string.IsNullOrEmpty(_userFile))
        {
            Console.Write("Enter the file name to save entries: ");
            _userFile = Console.ReadLine();
        }

        if (!string.IsNullOrEmpty(_userFile))
        {
            using (StreamWriter sw = new StreamWriter(_userFile, true))
            {
                foreach (var entry in _entries)
                {
                    sw.WriteLine(entry.ToString());
                    sw.WriteLine(); // Add a blank line between entries
                }
            }
            Console.WriteLine("Entries saved successfully.");
            
            UpdateStreak();
            
            _entries.Clear();
        }
        else
        {
            Console.WriteLine("Invalid file name. Please try again.");
        }
    }

    // Method to update the entry streak.
    private void UpdateStreak()
    {
        DateTime today = DateTime.Today;
        
        if (_lastEntryDate == default(DateTime))
        {
            // If no entries have been saved before, set the streak to 1.
            _entryStreak = 1;
        }
        else
        {
            // Calculate the difference in days between the last entry date and today.
            int difference = (today - _lastEntryDate).Days;

            if (difference == 1)
            {
                // If the difference is exactly 1 day, increment the streak.
                _entryStreak++;
            }
            else if (difference > 1)
            {
                // If the difference is greater than 1 day, reset the streak.
                _entryStreak = 1;
            }
        }

        // Update the last entry date to today.
        _lastEntryDate = today;

        // Display the current streak.
        Console.WriteLine($"Current Entry Streak: {_entryStreak} day(s). Keep it up!");
    }

    // Method to display both loaded and new entries.
    public void DisplayEntries()
    {
        if (_loadedEntries.Count > 0)
        {
            Console.WriteLine("Existing Entries:");
            foreach (var entry in _loadedEntries)
            {
                Console.WriteLine(entry.ToString());
                Console.WriteLine(); // Add a blank line between entries
            }
        }

        if (_entries.Count > 0)
        {
            Console.WriteLine("New Entries:");
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry.ToString());
                Console.WriteLine(); // Add a blank line between entries
            }
        }
    }
}
