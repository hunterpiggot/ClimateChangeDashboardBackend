using ClimateChangeDashboardBackend.Models;
using ClimateChangeDashboardBackendApi.Data;

namespace ClimateChangeDashboardBackend.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([Service] ApplicationDbContext context) =>
            context.Users;
    }
}
