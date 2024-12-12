
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int menuSelection = 0;
        while (menuSelection != 6)
        {
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out menuSelection))
            {
                if (menuSelection == 1)
                {
                    CreateGoal();
                }
                else if (menuSelection == 2)
                {
                    ListGoalDetails();
                }
                else if (menuSelection == 3)
                {
                    SaveGoals();
                }
                else if (menuSelection == 4)
                {
                    LoadGoals();
                }
                else if (menuSelection == 5)
                {
                    RecordEvent();
                }
                else if (menuSelection == 6)
                {
                    Console.WriteLine("Quitting the program...");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Player Score: {_score}");
    }

    public void ListGoalNames()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select the type of goal to create:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Enter your choice: ");

        if (int.TryParse(Console.ReadLine(), out int goalChoice))
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points = Convert.ToInt32(Console.ReadLine());

            if (goalChoice == 1)
            {
                _goals.Add(new SimpleGoal(name, description, points));
            }
            else if (goalChoice == 2)
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (goalChoice == 3)
            {
                Console.Write("What is the target number for the checklist? ");
                int target = Convert.ToInt32(Console.ReadLine());
                Console.Write("What is the bonus for completing the checklist? ");
                int bonus = Convert.ToInt32(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            }
            else
            {
                Console.WriteLine("Invalid goal type.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
        }
    }


    public void RecordEvent()
    {
        Console.WriteLine("Select the goal you accomplished:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            int pointsEarned = _goals[goalIndex - 1].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Recorded event for '{_goals[goalIndex - 1].GetDetailsString()}'. Points earned: {pointsEarned}. Total score: {_score}.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved.");
    }



    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                _goals.Clear();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    switch (parts[0])
                    {
                        case "SimpleGoal":
                            var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                            sg.IsComplete = bool.Parse(parts[4]);
                            _goals.Add(sg);
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                            break;
                        case "ChecklistGoal":
                            var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                            cg.TimesCompleted = int.Parse(parts[6]);
                            _goals.Add(cg);
                            break;
                    }
                }
            }
            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}