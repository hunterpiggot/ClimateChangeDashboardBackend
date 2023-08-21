
public class ClimateData
{
    public string Location { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public Dictionary<string, string> WeatherDetails { get; set; } = new Dictionary<string, string> { };
    public List<string> Forecast { get; set; } = new List<string>();
}