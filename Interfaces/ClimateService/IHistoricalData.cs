namespace ClimateChangeDashboardBackend.Interfaces
{
    public interface IHistoricalDataService
    {
        Task<HistoricalData> GetHistoricalDataAsync(string startDateTime, string endDateTime, string aggregation);
    }
}