using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTaskManager.API.DTOs;
using SmartTaskManager.API.Repositories.Interface;

namespace SmartTaskManager.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo) { _repo = repo; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _repo.GetAllAsync();
            return Ok(users.Select(u => new UserDto { Id = u.Id, Username = u.Username, Role = u.Role }));
        }
    }
}
