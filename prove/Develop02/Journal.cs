 
using System;
using System.Collections.Generic;
using System.IO;


// This class manages the collection of journal entries.
public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    private List<Entry> _loadedEntries = new List<Entry>();

    private string _userFile = "";

    private int _entryStreak = 0;

    private DateTime _lastEntryDate;

    public void AddEntry(string prompt, string content)
    {
        _entries.Add(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, content));
    }

    public void LoadFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            _userFile = filePath;
            _entries.Clear();
            _loadedEntries.Clear();

            
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
                    sw.WriteLine(); 
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


    private void UpdateStreak()
    {
        DateTime today = DateTime.Today;
        
        if (_lastEntryDate == default(DateTime))
        {
            _entryStreak = 1;
        }
        else
        {
            int difference = (today - _lastEntryDate).Days;

            if (difference == 1)
            {
                _entryStreak++;
            }
            else if (difference > 1)
            {
                _entryStreak = 1;
            }
        }

        _lastEntryDate = today;

        Console.WriteLine($"Current Entry Streak: {_entryStreak} day(s). Keep it up!");
    }

    public void DisplayEntries()
    {
        if (_loadedEntries.Count > 0)
        {
            Console.WriteLine("Existing Entries:");
            foreach (var entry in _loadedEntries)
            {
                Console.WriteLine(entry.ToString());
                Console.WriteLine(); 
            }
        }

        if (_entries.Count > 0)
        {
            Console.WriteLine("New Entries:");
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry.ToString());
                Console.WriteLine();
            }
        }
    }
}
