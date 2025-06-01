using Microsoft.EntityFrameworkCore;
using SmartTaskManager.API.Data;
using SmartTaskManager.API.Model;
using SmartTaskManager.API.Repositories.Interfaces; 

namespace SmartTaskManager.API.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Project?> GetWithTasksAsync(int id)
        {
            return await _context.Projects 
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
