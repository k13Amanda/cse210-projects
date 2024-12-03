using system;


public class Activity{

    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description,)
    {
    _name = name;
    _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Mindfulness Opportunities: {name} Activity");
        Console.WriteLine($"Welcome to the {name} Activity\n\n {description} How long, in seconds, would you like for your session?");
        string input = Console.ReadLine();
        if (int.TryParse(input, out _duration))
        {
            Console.WriteLine($"You have selected a {_duration} second breathing session.");
            // Here you can add the logic for the breathing activity
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Well Done!!\n\n You have completed another {duration} seconds of the {name} Activity");
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b"); // Backspace
            Console.Write("/");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b"); // Backspace
            Console.Write("/");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b"); // Backspace
            Console.Write("/");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b"); // Backspace
        

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


}