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

        [HttpGet("GetPersonelWithAllDetails/{personelId}")]
        public async Task<IActionResult> GetPersonelWithAllDetailsAsync(int personelId)
        {
            var personelWithDetails = await _personelService.GetPersonelWithAllDetailsAsync(personelId);
            return Ok(personelWithDetails);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Personel>> GetByIdAsync(int id)
        {
            var personel = await _personelService.GetByIdAsync(id);
            return Ok(personel);
        }

        [HttpGet("ByName/{name}")]
        public async Task<ActionResult<Personel>> GetByNameAsync(string name)
        {
            var personel = await _personelService.GetByNameAsync(name);
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
            await _personelService.DeleteAsync(id);
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
