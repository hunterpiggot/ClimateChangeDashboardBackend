using ClimateChangeDashboardBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClimateChangeDashboardBackendApi.Data.ContextConfigurations
{
    public class UserContextConfiguration : IEntityTypeConfiguration<User>
    {
        private Guid[] _ids;

        public UserContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasData(
                new User
                {
                    Id = _ids[0],
                    Username = "hunter",
                    Role = "BaseUser",
                    CreatedAt = "2023-08-20T03:11:44.569Z",
                    MembershipLevel = "basic",
                    Password = "abc123",
                    Country = "United States",
                    State = "Colorado",
                    City = "Colorado Springs",
                    Address = "123 Lake ave"
                },
                new User
                {
                    Id = _ids[1],
                    Username = "John",
                    Role = "BaseUser",
                    CreatedAt = "2023-07-03T03:03:44.569Z",
                    MembershipLevel = "basic",
                    Password = "abc123",
                    Country = "United States",
                    State = "Colorado",
                    City = "Colorado Springs",
                    Address = "123 Lake ave"
                },
                new User
                {
                    Id = _ids[2],
                    Username = "hunter",
                    Role = "BaseUser",
                    CreatedAt = "2023-06-27T03:21:44.569Z",
                    MembershipLevel = "basic",
                    Password = "abc123",
                    Country = "United States",
                    State = "Colorado",
                    City = "Colorado Springs",
                    Address = "123 Lake ave"
                });
        }
    }
}