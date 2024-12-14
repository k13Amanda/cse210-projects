

public class Running : Activity
{

    protected int _distance;

    public Running(DateTime date, string activity, int minutes, int distance) :base (date, activity, minutes)
    {
        _distance = distance;

    }

    public override double GetDistance()
    {
        return _distance;
    }
    public override double GetSpeed()
    {
        return (_distance / (double)_minutes) * 60;
    }

    public override double GetPace()
    {
    return (_minutes / (double)_distance);
    }

}




