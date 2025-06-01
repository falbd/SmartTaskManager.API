using SmartTaskManager.API.Model;

namespace SmartTaskManager.API.Repositories.Interface
{
    public interface IUserRepository : IGenericRepository<UserSmartTask>
    {
        Task<UserSmartTask?> GetByUsernameAsync(string username);
    }
}
