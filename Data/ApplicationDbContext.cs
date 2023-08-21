using ClimateChangeDashboardBackend.Models;
using ClimateChangeDashboardBackendApi.Data.ContextConfigurations;
using Microsoft.EntityFrameworkCore;


namespace ClimateChangeDashboardBackendApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Generate three GUIDS and place them in an arrays
            var ids = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

            // Apply configuration for the three contexts in our application
            // This will create the demo data for our GraphQL endpoint.
            builder.ApplyConfiguration(new UserContextConfiguration(ids));
            builder.ApplyConfiguration(new FeedbackContextConfiguration(ids));
            builder.ApplyConfiguration(new AnalyticsContextConfiguration(ids));
        }

        // Add the DbSets for each of our models we would like at our database
        public DbSet<User> Users { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Analytics> Analytics { get; set; }
    }
}