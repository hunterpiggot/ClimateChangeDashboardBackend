using ClimateChangeDashboardBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimateChangeDashboardBackendApi.Data.ContextConfigurations
{
    public class FeedbackContextConfiguration : IEntityTypeConfiguration<Feedback>
    {
        private Guid[] _ids;

        public FeedbackContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder
                .HasData(
                new Feedback
                {
                    Id = Guid.NewGuid(),
                    Title = "title",
                    Body = "this is the body",
                    UserId = _ids[0],
                    Status = "pending",
                    Role = "BaseUser",
                    CreatedAt = "2023-08-20T03:11:44.569Z"
                },
                new Feedback
                {
                    Id = Guid.NewGuid(),
                    Title = "title 2",
                    Body = "this is the body 2",
                    UserId = _ids[1],
                    Status = "pending",
                    Role = "BaseUser",
                    CreatedAt = "2023-08-20T03:11:44.569Z"
                });


        }
    }
}