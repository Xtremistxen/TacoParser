namespace LoggingKata;

public class TacoBell : ITrackable
{
    //This is the Tacobell location tracker
    public TacoBell()
    {
    }

    public string Name { get; set; }
    public Point Location { get; set; }
}