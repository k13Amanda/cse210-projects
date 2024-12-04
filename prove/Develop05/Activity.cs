using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description) 
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Mindfulness Opportunities: {_name} Activity"); 
        Console.WriteLine($"Welcome to the {_name} Activity\n\n{_description}\nHow long, in seconds, would you like for your session?"); // Use _name and _description
        string input = Console.ReadLine();
        if (int.TryParse(input, out _duration))
        {
            
            Console.WriteLine($"You have selected a {_duration} second {_name} session."); 
            Console.Clear();
            Console.WriteLine("Get Ready...\n");
            ShowSpinner(3);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell Done!!\n\nYou have completed another {_duration} seconds of the {_name} Activity");
    }

    public virtual void Run() //Polymorphism, this is next weeks lesson but i learned how to do it while studing for this week so i added it in my program. 
    {
        
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b"); 
            Console.Write("-");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b"); 
            Console.Write("\\");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b"); 
            Console.Write("|");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b"); 
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void ShowTimerBar(int totalSeconds)
    {
        int progressBarLength = 50;
        for (int i = 0; i < totalSeconds; i++)
        {
            double progress = (double)i / totalSeconds;
            int filledLength = (int)(progressBarLength * progress);
            string bar = new string('#', filledLength) + new string('-', progressBarLength - filledLength);
            Console.Write($"\r[{bar}] {i + 1}/{totalSeconds} seconds");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

}
