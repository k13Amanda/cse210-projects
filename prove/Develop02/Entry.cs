using System;

// This class represents a single journal entry.
public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Content { get; set; }

    // Constructor to initialize a new Entry with date, prompt, and content.
    public Entry(string date, string prompt, string content)
    {
        Date = date;
        Prompt = prompt;
        Content = content;
    }

    // Override ToString to format the entry as a string.
    public override string ToString()
    {
        return $"Date: {Date} - Prompt: {Prompt}\nEntry: {Content}";
    }
}
