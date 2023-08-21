using ClimateChangeDashboardBackend.Models;

namespace ClimateChangeDashboardBackend.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid userId);
    }
}