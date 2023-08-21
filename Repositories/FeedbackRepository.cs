

using ClimateChangeDashboardBackend.Interfaces;
using ClimateChangeDashboardBackendApi.Data;

namespace ClimateChangeDashboardBackendApi.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public FeedbackRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}