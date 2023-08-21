namespace ClimateChangeDashboardBackend.Interfaces
{
    public interface IClimateService
    {
        Task<ClimateData> GetClimateDataAsync(string location);
    }
}