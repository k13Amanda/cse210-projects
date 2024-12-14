

public class Cycling : Activity
{

    protected int _speed;


    public Cycling(DateTime date, string activity, int minutes, int speed) :base (date, activity, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * (_minutes / 60.0) ;
        
    }
    public override double GetSpeed()
    {
        return _speed;
    }
    public override double GetPace()
    {
        return _minutes / GetDistance();
    }

}




