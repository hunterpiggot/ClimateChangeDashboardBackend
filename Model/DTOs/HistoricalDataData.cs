

using Newtonsoft.Json;

enum HistoricalDataAggregationEnum
{
    None,
    Hour,
    Day,
    Week,
    Month,
    Year,
    Decade
}

public class HistoricalDataHourly
{
    public List<string> Time { get; set; } = new List<string>();
    [JsonProperty("temperature_2m")]
    public List<double?> TemperatureTwoM { get; set; } = new List<double?>();

}

public class HistoricalDataCombinedData
{
    public string Time { get; set; } = string.Empty;
    [JsonProperty("temperature_2m")]
    public double? TemperatureTwoM { get; set; }

}

public class HistoricalDataHourlyUnits
{
    public string Time { get; set; } = string.Empty;
    [JsonProperty("temperature_2m")]
    public string TemperatureTwoM { get; set; } = string.Empty;
}
public class HistoricalData
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    [JsonProperty("generationtime_ms")]
    public double GenerationTimeMs { get; set; }
    [JsonProperty("utc_offset_seconds")]
    public double UtcOffsetSeconds { get; set; }
    public string Timezone { get; set; } = string.Empty;
    [JsonProperty("timezone_abbreviation")]
    public string TimezoneAbbreviation { get; set; } = string.Empty;
    public double Elevation { get; set; }
    [JsonProperty("hourly_units")]
    public HistoricalDataHourlyUnits HourlyUnits { get; set; } = new HistoricalDataHourlyUnits();
    public HistoricalDataHourly Hourly { get; set; } = new HistoricalDataHourly();
    // public string Location { get; set; } = string.Empty;
    // public double Temperature { get; set; }
    // public Dictionary<string, string> WeatherDetails { get; set; } = new Dictionary<string, string> { };
    // public List<string> Forecast { get; set; } = new List<string>();
}