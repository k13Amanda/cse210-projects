
public class Goal{

    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points){
        _shortName = name;
        _description = description;
        _points = points;
    }

     public bool IsComplete();
     public abstract int RecordEvent();

     public string GetDetailsString(){
        return $"[ ] {_shortName} - {_description}";
    }

     public string GetStringRepresentation();
    }
}