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
            return Ok(await _departmentService.GetAllAsync());
        }

        [HttpGet("GetDepartmentPersonnelInformationAsync")]
        public async Task<IActionResult> GetDepartmentPersonnelInformationAsync(int departmentID)
        {
            var departmentPersonelInformation = await _departmentService.GetDepartmentPersonnelInformationAsync(departmentID);
            return Ok(departmentPersonelInformation);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Department>> GetByIdAsync(int id)
        {
            var departments = await _departmentService.GetByIdAsync(id);
            return Ok(departments);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] DepartmentViewModel department)
        {
            return Ok(await _departmentService.AddAsync(department));
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int departmentID)
        {
            return Ok(await _departmentService.DeleteAsync(departmentID));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(DepartmentViewModel department)
        {
            return Ok(await _departmentService.UpdateAsync(department));
        }

        

    }
}
