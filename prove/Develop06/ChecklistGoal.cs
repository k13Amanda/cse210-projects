public class ChecklistGoal : Goal{

    private int _amountCompleted;
    private int _target;
    private int _bonus;

   public ChecklistGoal(string name, string description, int points, int target, int bonus) :base (name, description, points)
   {
        _amountCompleted = 0;
        _bonus = bonus;
        _target = target;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted >= _target)
        {
            return _points + _bonus;
        }
        return _points;
    }

     public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkBox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkBox} {_shortName} - {_description} (Completed {_amountCompleted}/{_target} times)";

    }

     public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
    }

}
