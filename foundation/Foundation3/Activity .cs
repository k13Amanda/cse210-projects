
public abstract class Activity
{
    protected DateTime _date;
    protected int _minutes;
    protected string _activity;

    public Activity(DateTime date, string activity, int minutes)
    {
    _date = date;
    _activity = activity;
    _minutes = minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();


    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {_activity} ({_minutes} min) - Distance: {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }


}