

public class NaturalEventsMagnitudeData
{
    public int Current { get; set; }
    public int Minimum { get; set; }
    public int Maximum { get; set; }

}

public class NaturalEventsCoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
public class NaturalEventsData
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public NaturalEventsMagnitudeData Magnitude { get; set; } = new NaturalEventsMagnitudeData();
    public string Date { get; set; } = string.Empty;
    public NaturalEventsCoordinates Coordinates { get; set; } = new NaturalEventsCoordinates();
    // public string Location { get; set; } = string.Empty;
    // public double Temperature { get; set; }
    // public Dictionary<string, string> WeatherDetails { get; set; } = new Dictionary<string, string> { };
    // public List<string> Forecast { get; set; } = new List<string>();
}