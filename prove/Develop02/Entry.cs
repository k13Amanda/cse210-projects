using System;

// This class represents a single journal entry.
public class Entry
{
    public string _date { get; set; }
    public string _prompt { get; set; }
    public string _content { get; set; }

    // Constructor to initialize a new Entry with date, prompt, and content.
    public Entry(string date, string prompt, string content)
    {
        _date = date;
        _prompt = prompt;
        _content = content;
    }

    // Override ToString to format the entry as a string.
    public override string ToString()
    {
        return $"Date: {_date} - Prompt: {_prompt}\nEntry: {_content}";
    }
}
