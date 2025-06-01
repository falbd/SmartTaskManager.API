using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTaskManager.API.Data;
using SmartTaskManager.API.DTOs;
using SmartTaskManager.API.Model;
using SmartTaskManager.API.Repositories.Interfaces; 

namespace SmartTaskManager.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _repo;
        private readonly ApplicationDbContext _context;

        public ProjectController(IProjectRepository repo, ApplicationDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAll()
        {
            var projects = await _repo.GetAllAsync();
            return Ok(projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            }));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateProjectDto dto)
        {
            var project = new Project
            {
                Name = dto.Name,
                Description = dto.Description
            };

            await _repo.AddAsync(project);
            await _context.SaveChangesAsync();

            return Ok("Project created");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateProjectDto dto)
        {
            var project = await _repo.GetByIdAsync(id);
            if (project == null) return NotFound();

            project.Name = dto.Name;
            project.Description = dto.Description;

            _repo.Update(project);
            await _context.SaveChangesAsync();

            return Ok("Project updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var project = await _repo.GetByIdAsync(id);
            if (project == null) return NotFound();

            _repo.Remove(project);
            await _context.SaveChangesAsync();

            return Ok("Project deleted");
        }
    }
}
