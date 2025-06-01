using SmartTaskManager.API.Model;

namespace SmartTaskManager.API.Services
{
    public interface IAuthService
    {
        string GenerateToken(UserSmartTask user);
        void CreatePasswordHash(string password, out byte[] hash, out byte[] salt);
        bool VerifyPassword(string password, byte[] hash, byte[] salt);
    }
}
