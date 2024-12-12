public class SimpleGoal : Goal{

    private bool _isComplete;

   public SimpleGoal(string name, string description, int points) :base (name, description, points)
   {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        if (_isComplete == true)
        {
            return _points;
        }
    }

     public override bool IsComplete()
     {
        return true;
    }

     public override string GetStringRepresentation()
     {
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_isComplete}";
    }

    public override string GetDetailsString()
    {
        string checkBox = _isComplete ? "[X]" : "[ ]";
        return $"{checkBox} {_shortName} - {_description}"; 
    }

}