using Microsoft.EntityFrameworkCore;
using SmartTaskManager.API.Data;
using SmartTaskManager.API.Model;
using SmartTaskManager.API.Repositories.Interface;

namespace SmartTaskManager.API.Repositories.Implementation
{
    public class TaskRepository : GenericRepository<TaskItem>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<TaskItem>> GetByProjectIdAsync(int projectId) =>
            await _dbSet.Where(t => t.ProjectId == projectId).ToListAsync();

        public async Task<IEnumerable<TaskItem>> GetByUserIdAsync(int userId) =>
            await _dbSet.Where(t => t.UserId == userId).ToListAsync();
    }
}
