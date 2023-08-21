
using ClimateChangeDashboardBackend.Interfaces;
using ClimateChangeDashboardBackend.Models;
using ClimateChangeDashboardBackendApi.Data;
using Microsoft.EntityFrameworkCore;


namespace ClimateChangeDashboardBackendApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public UserRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var user = await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found"); // Or handle this however you like
            }
            return user;
        }
    }
}