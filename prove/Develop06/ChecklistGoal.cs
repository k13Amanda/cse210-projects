public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _bonus = bonus;
        _target = target;
    }

    public int TimesCompleted
    {
        get { return _amountCompleted; }
        set { _amountCompleted = value; }
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        int pointsEarned = Points; // Regular points for each completion

        if (_amountCompleted >= _target)
        {
            pointsEarned += _bonus; // Add bonus if target is reached
            Console.WriteLine($"Checklist goal '{_shortName}' completed! You've earned {Points} points plus a {_bonus} point bonus!");
        }
        else
        {
            Console.WriteLine($"Checklist goal '{_shortName}' recorded! {_amountCompleted}/{_target} completed. You've earned {Points} points.");
        }

        // Add points to the manager's score
        GoalManager.Instance.AddPoints(pointsEarned);
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkBox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkBox} {_shortName} - {_description} (Currently Completed: {_amountCompleted}/{_target})";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{Points}|{_target}|{_bonus}|{_amountCompleted}";
    }
}
