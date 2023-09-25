namespace ClimateChangeDashboardBackend.Interfaces
{
    public interface IHistoricalDataService
    {
        Task<List<HistoricalDataData>> GetHistoricalDataDataAsync();
    }
}