using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace TekhnelogosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Project>>> GetAll()
        {
            var departments = await _projectService.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Project>> GetByIdAsync(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            return Ok(project);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ProjectViewModel project)
        {
            await _projectService.AddAsync(project);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int projectID)
        {
            await _projectService.DeleteAsync(projectID);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProjectViewModel project)
        {

            await _projectService.UpdateAsync(project);
            return NoContent();
        }
    }
}
