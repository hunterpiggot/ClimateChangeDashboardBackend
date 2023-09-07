using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClimateChangeDashboardBackend.Interfaces;

public class NaturalEventsService : INaturalEventsService
{
    public async Task<List<NaturalEventsData>> GetNaturalEventsDataAsync()
    {
        string filePath = "mock-data/natural-events.json";

        // Read the file asynchronously
        using (StreamReader r = new StreamReader(filePath))
        {
            string json = await r.ReadToEndAsync();

            // Deserialize the JSON into a List of NaturalEventsData
            List<NaturalEventsData> naturalEventsData = JsonConvert.DeserializeObject<List<NaturalEventsData>>(json);

            // You might want to filter by location here
            // ...

            return naturalEventsData;
        }
    }
}
