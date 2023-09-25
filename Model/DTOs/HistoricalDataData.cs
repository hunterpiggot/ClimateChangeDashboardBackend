

public class HistoricalDataMagnitudeData
{
    public int Current { get; set; }
    public int Minimum { get; set; }
    public int Maximum { get; set; }

}

public class HistoricalDataCoordinates
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
public class HistoricalDataData
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public HistoricalDataMagnitudeData Magnitude { get; set; } = new HistoricalDataMagnitudeData();
    public string Date { get; set; } = string.Empty;
    public HistoricalDataCoordinates Coordinates { get; set; } = new HistoricalDataCoordinates();

    public List<double> TemperatureTwoM = new List<double>();
    // public string Location { get; set; } = string.Empty;
    // public double Temperature { get; set; }
    // public Dictionary<string, string> WeatherDetails { get; set; } = new Dictionary<string, string> { };
    // public List<string> Forecast { get; set; } = new List<string>();
}