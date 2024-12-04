using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        int totalDuration = _duration; 
        int cycleDuration = 10;

        while (totalDuration > 0)
        {
            if (totalDuration >= cycleDuration)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(5);
                Console.WriteLine("Breathe out...");
                ShowCountDown(5);
                totalDuration -= cycleDuration; 
            }
            else
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(totalDuration / 2);
                Console.WriteLine("Breathe out...");
                ShowCountDown(totalDuration / 2);
                totalDuration = 0; 
            }
        }
        DisplayEndingMessage();
    }
}
