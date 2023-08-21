using ClimateChangeDashboardBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimateChangeDashboardBackendApi.Data.ContextConfigurations
{
    public class AnalyticsContextConfiguration : IEntityTypeConfiguration<Analytics>
    {
        private Guid[] _ids;

        public AnalyticsContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Analytics> builder)
        {
            builder
                .HasData(
                new Analytics
                {
                    Id = Guid.NewGuid(),
                    UserId = _ids[0],
                    SessionId = Guid.NewGuid(),
                    PageViewed = "ClimateChangeDashboard",
                    TimeStamp = "2023-08-20T03:11:44.569Z",
                    DeviceType = "Desktop",
                    Browser = "Chrome",
                    ReferrerUrl = "www.google.com"
                },
                new Analytics
                {
                    Id = Guid.NewGuid(),
                    UserId = _ids[1],
                    SessionId = Guid.NewGuid(),
                    PageViewed = "ClimateChangeDashboard",
                    TimeStamp = "2023-08-20T03:11:44.569Z",
                    DeviceType = "Desktop",
                    Browser = "Chrome",
                    ReferrerUrl = "www.google.com"
                },
                new Analytics
                {
                    Id = Guid.NewGuid(),
                    UserId = _ids[2],
                    SessionId = Guid.NewGuid(),
                    PageViewed = "ClimateChangeDashboard",
                    TimeStamp = "2023-08-20T03:11:44.569Z",
                    DeviceType = "Desktop",
                    Browser = "Chrome",
                    ReferrerUrl = "www.google.com"
                });
        }
    }
}