namespace ClimateChangeDashboardBackend.Interfaces
{
    public interface INaturalEventsService
    {
        Task<List<NaturalEventsData>> GetNaturalEventsDataAsync();
    }
}