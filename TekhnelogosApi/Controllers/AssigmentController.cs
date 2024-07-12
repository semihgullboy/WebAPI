using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TekhnelogosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssigmentController : ControllerBase
    {
        private readonly IAssigmentService _asigmentService;

        public AssigmentController(IAssigmentService asigmentService)
        {
            _asigmentService = asigmentService;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<Assignment>>> GetAll()
        {
            var result = await _asigmentService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetById(int id)
        {
            var result = await _asigmentService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Assignment assignment)
        {
            await _asigmentService.AddAsync(assignment);
            return Ok();
        }

        [HttpDelete("delete{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var personel = await _asigmentService.GetByIdAsync(id);
            if (personel == null)
            {
                return NotFound();
            }

            await _asigmentService.DeleteAsync(personel);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Assignment assignment)
        {
            await _asigmentService.UpdateAsync(assignment);
            return NoContent();
        }
    }
}
