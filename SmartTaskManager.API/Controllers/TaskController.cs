using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTaskManager.API.Data;
using SmartTaskManager.API.DTOs;
using SmartTaskManager.API.Model;
using SmartTaskManager.API.Repositories.Interface;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository _repo;
    private readonly ApplicationDbContext _context;

    public TaskController(ITaskRepository repo, ApplicationDbContext context)
    {
        _repo = repo;
        _context = context;
    }

    [HttpGet("project/{projectId}")]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetByProject(int projectId)
    {
        var tasks = await _repo.GetByProjectIdAsync(projectId);
        return Ok(tasks.Select(t => new TaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            Status = t.Status,
            UserId = t.UserId,
            ProjectId = t.ProjectId
        }));
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            UserId = dto.UserId,
            ProjectId = dto.ProjectId
        };
        await _repo.AddAsync(task);
        await _context.SaveChangesAsync();
        return Ok("Task created");
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateTaskDto dto)
    {
        var task = await _repo.GetByIdAsync(id);
        if (task == null) return NotFound();

        task.Title = dto.Title;
        task.Description = dto.Description;
        task.Status = dto.Status;
        task.UserId = dto.UserId;
        task.ProjectId = dto.ProjectId;

        _repo.Update(task);
        await _context.SaveChangesAsync();
        return Ok("Task updated");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var task = await _repo.GetByIdAsync(id);
        if (task == null) return NotFound();

        _repo.Remove(task);
        await _context.SaveChangesAsync();
        return Ok("Task deleted");
    }
}
