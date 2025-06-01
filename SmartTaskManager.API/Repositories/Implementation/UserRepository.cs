using Microsoft.EntityFrameworkCore;
using SmartTaskManager.API.Data;
using SmartTaskManager.API.Model;
using SmartTaskManager.API.Repositories.Interface;

namespace SmartTaskManager.API.Repositories.Implementation
{
    public class UserRepository : GenericRepository<UserSmartTask>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<UserSmartTask?> GetByUsernameAsync(string username) =>
            await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
    }
}
