public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private static GoalManager _instance;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _instance = this;
    }

    public static GoalManager Instance
    {
        get { return _instance; }
    }

    public void AddPoints(int points)
    {
        _score += points;
        Console.WriteLine($"Total score: {_score}.");
    }

    public void Start()
    {
        int menuSelection = 0;
        while (menuSelection != 6)
        {
            Console.WriteLine($"You have {_score} points.\n");
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
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = Convert.ToInt32(Console.ReadLine());
                Console.Write("What is the bonus for completing it that many times? ");
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
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalIndex - 1];
            
            if (selectedGoal.IsComplete())
            {
                Console.WriteLine("This goal has already been completed.");
            }
            else
            {
                selectedGoal.RecordEvent();
            }

            Console.WriteLine($"Recorded event for '{selectedGoal.GetDetailsString()}'. Total score: {_score}.");
            Console.WriteLine("********    :)    *********");
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select a valid goal number.");
        }
    }


    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score); // Save the score on the first line

            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals and score saved.");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                _goals.Clear();
                
                // Load the score from the first line
                if (int.TryParse(reader.ReadLine(), out int loadedScore))
                {
                    _score = loadedScore;
                }

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts[0] == "SimpleGoal")
                    {
                        var sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        sg.GetType().GetField("_isComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(sg, bool.Parse(parts[4]));
                        _goals.Add(sg);
                    }
                    else if (parts[0] == "EternalGoal")
                    {
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    }
                    else if (parts[0] == "ChecklistGoal")
                    {
                        var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                        cg.TimesCompleted = int.Parse(parts[6]);
                        _goals.Add(cg);
                    }
                }
            }
            Console.WriteLine("Goals and score loaded.");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}
