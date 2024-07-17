using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace TekhnelogosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Title>>> GetAll()
        {
            var departments = await _titleService.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<Title>> GetByIdAsync(int id)
        {
            var title = await _titleService.GetByIdAsync(id);
            if (title == null)
            {
                return NotFound();
            }
            return Ok(title);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(TitleViewModel title)
        {
            await _titleService.AddAsync(title);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete(int titleID)
        {
            await _titleService.DeleteAsync(titleID);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(TitleViewModel title)
        {

            await _titleService.UpdateAsync(title);
            return NoContent();
        }
    }
}
