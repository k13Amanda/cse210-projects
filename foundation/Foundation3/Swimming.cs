

public class Swimming : Activity
{

    protected int _numberLaps;


    public Swimming(DateTime date, string activity, int minutes, int laps) :base (date, activity, minutes)
    {
    _numberLaps = laps;
    }

    public override double GetDistance()
    {
        return _numberLaps * 50 / 1000.0 * 0.62;
    }
    public override double GetSpeed()
    {
        return GetDistance() / (_minutes / 60.0);
    }

    public override double GetPace()
    {
        return _minutes / GetDistance();
    }

}