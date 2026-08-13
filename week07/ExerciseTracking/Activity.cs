using System.Globalization;

public abstract class Activity
{
    private DateTime _date;
    private int _lengthInMinutes;

    protected Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    protected DateTime GetDate()
    {
        return _date;
    }

    protected int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }

    protected abstract string GetActivityName();

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public string GetSummary()
    {
        CultureInfo englishCulture = CultureInfo.GetCultureInfo("en-US");
        return $"{_date.ToString("dd MMM yyyy", englishCulture)} {GetActivityName()} ({_lengthInMinutes} min) - " +
               $"Distance {GetDistance().ToString("F1", englishCulture)} km, " +
               $"Speed {GetSpeed().ToString("F1", englishCulture)} kph, " +
               $"Pace: {GetPace().ToString("F2", englishCulture)} min per km";
    }
}
