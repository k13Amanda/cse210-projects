using System;
using System.Collections.Generic;

public class StretchingActivity : Activity
{
    private List<string> _stretches = new List<string>
    {
        "Neck Stretch: Slowly tilt your head to the left, bringing your left ear towards your left shoulder. Hold for 10 seconds, then switch sides.",
        "Shoulder Stretch: Bring your right arm across your chest, and use your left arm to gently press your right arm towards your chest. Hold for 10 seconds, then switch sides.",
        "Upper Back Stretch: Interlace your fingers and extend your arms in front of you, pushing your palms away from your body. Round your upper back and hold for 10 seconds.",
        "Side Stretch: Raise your right arm overhead and bend to the left, feeling the stretch along your right side. Hold for 10 seconds, then switch sides.",
        "Hamstring Stretch: Sit on the floor with your legs extended. Reach towards your toes, keeping your back straight. Hold for 10 seconds."
    };

    public StretchingActivity()
        : base("Stretching", "This activity will guide you through a series of stretches to improve flexibility and reduce muscle tension.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Let's get started with some stretches!");

        foreach (var stretch in _stretches)
        {
            Console.WriteLine(stretch);
            ShowCountDown(10);
            Console.Clear();
        }

        DisplayEndingMessage();
    }
}
