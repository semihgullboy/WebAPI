using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace TekhnelogosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IPersonelService _personelService;

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Personel>>> GetAll()
        {
            var personels = await _personelService.GetAllAsync();
            return Ok(personels);
        }

        [HttpGet("GetPersonelWithAllDetails")]
        public async Task<IActionResult> GetPersonelWithAllDetailsAsync(int personelId)
        {
            if (personelId <= 0)
            {
                return BadRequest("Invalid personel ID.");
            }

            var personelWithDetails = await _personelService.GetPersonelWithAllDetailsAsync(personelId);

            if (personelWithDetails == null)
            {
                return NotFound("Department not found for the given personel ID.");
            }

            return Ok(personelWithDetails);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Personel>> GetByIdAsync(int id)
        {
            var personel = await _personelService.GetByIdAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            return Ok(personel);
        }

        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<Personel>> GetByNameAsync(string name)
        {
            var personel = await _personelService.GetByNameAsync(name);
            if (personel == null)
            {
                return NotFound();
            }
            return Ok(personel);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(PersonelViewModel viewmodel)
        {
            await _personelService.AddAsync(viewmodel);
            return Ok();
        }

        [HttpDelete("delete{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var personel = await _personelService.GetByIdAsync(id);
            if (personel == null)
            {
                return NotFound();
            }

            await _personelService.DeleteAsync(personel);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(PersonelViewModel viewModel)
        {

            await _personelService.UpdateAsync(viewModel);
            return NoContent();
        }

    }
}
