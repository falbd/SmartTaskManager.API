using Microsoft.AspNetCore.Mvc;
using SmartTaskManager.API.Data;
using SmartTaskManager.API.DTOs;
using SmartTaskManager.API.Model;
using SmartTaskManager.API.Repositories.Interface;
using SmartTaskManager.API.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepo;
    private readonly IAuthService _authService;
    private readonly ApplicationDbContext _context;

    public AuthController(IUserRepository userRepo, IAuthService authService, ApplicationDbContext context)
    {
        _userRepo = userRepo;
        _authService = authService;
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var existingUser = await _userRepo.GetByUsernameAsync(dto.Username);
        if (existingUser != null) return BadRequest("Username already exists.");

        _authService.CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);

        var user = new UserSmartTask
        {
            Username = dto.Username,
            PasswordHash = hash,
            PasswordSalt = salt,
            Role = "User"
        };

        await _userRepo.AddAsync(user);
        await _context.SaveChangesAsync();

        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _userRepo.GetByUsernameAsync(dto.Username);
        if (user == null || !_authService.VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
            return Unauthorized("Invalid credentials.");

        var token = _authService.GenerateToken(user);
        return Ok(new { token });
    }
}
