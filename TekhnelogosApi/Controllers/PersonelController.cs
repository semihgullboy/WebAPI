using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("getall")]
        public async Task<ActionResult<List<Personel>>> GetAll()
        {
            var result = await _personelService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personel>> GetById(int id)
        {
            var result = await _personelService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Personel personel)
        {
            await _personelService.AddAsync(personel);
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

        [HttpPut]
        public async Task<ActionResult> Update(Personel personel)
        {
            await _personelService.UpdateAsync(personel);
            return NoContent();
        }

    }
}
