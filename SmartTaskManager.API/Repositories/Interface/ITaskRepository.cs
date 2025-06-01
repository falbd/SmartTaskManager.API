using SmartTaskManager.API.Model;

namespace SmartTaskManager.API.Repositories.Interface
{
    public interface ITaskRepository : IGenericRepository<TaskItem>
    {
        Task<IEnumerable<TaskItem>> GetByProjectIdAsync(int projectId);
        Task<IEnumerable<TaskItem>> GetByUserIdAsync(int userId);
    }
}
