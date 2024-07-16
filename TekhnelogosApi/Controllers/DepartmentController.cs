using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace TekhnelogosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    { 
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Department>>> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("GetDepartmentPersonnelInformationAsync")]
        public async Task<IActionResult> GetDepartmentPersonnelInformationAsync(int departmentID)
        {
            if (departmentID <= 0)
            {
                return BadRequest("Invalid department ID.");
            }

            var departmentPersonelInformation = await _departmentService.GetDepartmentPersonnelInformationAsync(departmentID);

            if (departmentPersonelInformation == null)
            {
                return NotFound("Department not found for the given personel ID.");
            }

            return Ok(departmentPersonelInformation);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Department>> GetByIdAsync(int id)
        {
            var departments = await _departmentService.GetByIdAsync(id);
            if (departments == null)
            {
                return NotFound();
            }
            return Ok(departments);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(DepartmentViewModel department)
        {
            await _departmentService.AddAsync(department);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(Department department)
        {
            await _departmentService.DeleteAsync(department);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Department department)
        {

            await _departmentService.UpdateAsync(department);
            return NoContent();
        }

        

    }
}
