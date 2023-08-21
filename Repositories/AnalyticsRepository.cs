using ClimateChangeDashboardBackend.Interfaces;
using ClimateChangeDashboardBackendApi.Data;

namespace ClimateChangeDashboardBackendApi.Repositories
{
    public class AnalyticsRepository : IAnalyticsRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public AnalyticsRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}