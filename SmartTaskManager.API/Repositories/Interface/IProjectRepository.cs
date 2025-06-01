using SmartTaskManager.API.Model;
using SmartTaskManager.API.Repositories.Interface;

namespace SmartTaskManager.API.Repositories.Interfaces
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<Project?> GetWithTasksAsync(int id);
    }
}
