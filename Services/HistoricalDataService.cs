using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClimateChangeDashboardBackend.Interfaces;

public class HistoricalDataService : IHistoricalDataService
{
    public async Task<HistoricalData> GetHistoricalDataAsync(string startDateTimeString, string endDateTimeString, string aggregation)
    {
        HistoricalData data = await ReadAndDeserializeJsonData("mock-data/historical-data-long.json");

        if (data != null && aggregation != "none")
        {
            if (Enum.TryParse(aggregation, true, out HistoricalDataAggregationEnum aggregationType))
            {
                data = AggregateData(data, startDateTimeString, endDateTimeString, aggregationType);
            }
            else
            {
                // return "error";
                // Handle invalid aggregation type
            }
        }
        return data ?? new HistoricalData();
    }

    private async Task<HistoricalData> ReadAndDeserializeJsonData(string filePath)
    {
        HistoricalData? data;

        // Read the file asynchronously
        using (StreamReader r = new StreamReader(filePath))
        {
            string json = await r.ReadToEndAsync();

            // Deserialize the JSON into a List of HistoricalData
            data = JsonConvert.DeserializeObject<HistoricalData>(json);

            // You might want to filter by location here
            // ...

        }
        // Read and deserialize logic here
        // ...
        return data ?? new HistoricalData(); // Placeholder
    }

    private HistoricalData AggregateData(HistoricalData data, string startDateTimeString, string endDateTimeString, HistoricalDataAggregationEnum aggregationType)
    {
        DateTime startDateTime = DateTime.Parse(startDateTimeString, null, System.Globalization.DateTimeStyles.RoundtripKind);
        DateTime endDateTime = DateTime.Parse(endDateTimeString, null, System.Globalization.DateTimeStyles.RoundtripKind);

        DateTime currentDate = new();
        List<double> currentValues = new();
        List<double?> runningAverages = new();
        List<string> stringDateTimes = new();

        for (int i = 0; i < data.Hourly.Time.Count; i++)
        {
            DateTime pointDateTime = DateTime.Parse(data.Hourly.Time[i], null, System.Globalization.DateTimeStyles.RoundtripKind);
            // New: Check if the pointDateTime is within the date range
            if (pointDateTime < startDateTime || pointDateTime > endDateTime)
            {
                continue; // Skip this iteration if the date is out of range
            }

            if (i == 0)
            {
                currentDate = pointDateTime;
            }

            bool shouldAggregate = false;

            switch (aggregationType)
            {
                case HistoricalDataAggregationEnum.Hour:
                    shouldAggregate = currentDate.Hour != pointDateTime.Hour;
                    break;
                case HistoricalDataAggregationEnum.Day:
                    shouldAggregate = currentDate.Day != pointDateTime.Day;
                    break;
                case HistoricalDataAggregationEnum.Week:
                    shouldAggregate = currentDate.Date.AddDays(-(int)currentDate.DayOfWeek).Date != pointDateTime.Date.AddDays(-(int)pointDateTime.DayOfWeek).Date;
                    break;
                case HistoricalDataAggregationEnum.Month:
                    shouldAggregate = currentDate.Month != pointDateTime.Month;
                    break;
                case HistoricalDataAggregationEnum.Year:
                    shouldAggregate = currentDate.Year != pointDateTime.Year;
                    break;
                case HistoricalDataAggregationEnum.Decade:
                    shouldAggregate = (currentDate.Year / 10) != (pointDateTime.Year / 10);
                    break;
            }

            if (shouldAggregate)
            {
                if (currentValues.Count > 0)
                {
                    // Update the current date and calculate the average
                    currentDate = pointDateTime;
                    double average = currentValues.Average();
                    runningAverages.Add(average);
                    stringDateTimes.Add(data.Hourly.Time[i]);

                    // Clear current values for the next aggregation
                    currentValues.Clear();

                }
                else
                {
                    currentDate = pointDateTime;
                    // runningAverages.Add(0);
                    // stringDateTimes.Add(data.Hourly.Time[i]);
                    currentValues.Clear();
                }
            }

            double? currentTempValue = data.Hourly.TemperatureTwoM[i];
            currentValues.Add(currentTempValue ?? 0);
        }

        data.Hourly.Time = stringDateTimes;
        data.Hourly.TemperatureTwoM = runningAverages.Select(d => (double?)d).ToList();

        // Aggregation logic here
        // ...
        return data; // Placeholder
    }
}
