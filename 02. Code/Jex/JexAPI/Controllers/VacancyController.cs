using JexAPI.Models;
using JexAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JexAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _vacancyService;

        public VacancyController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacancyDto>>> GetVacancies([FromQuery] bool? published = null)
        {
            var vacancies = await _vacancyService.GetVacanciesAsync(published);
            return Ok(vacancies);
        }

        [HttpGet("{id:guid}", Name = "GetVacancyById")]
        public async Task<ActionResult<VacancyDto>> GetVacancyById(Guid id)
        {
            var vacancy = await _vacancyService.GetVacancyByIdAsync(id);

            return vacancy == null
                        ? NotFound()
                        : Ok(vacancy);
        }

        [HttpPost]
        public async Task<ActionResult<VacancyDto>> CreateVacancy([FromBody] VacancyDto vacancyDto)
        {
            var newVacancy = await _vacancyService.CreateVacancyAsync(vacancyDto);

            return CreatedAtRoute("GetVacancyById",
                                    new { id = newVacancy.Id },
                                    newVacancy);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<VacancyDto>> UpdateVacancy(Guid id, [FromBody] VacancyDto vacancyDto)
        {
            var updatedVacancy = await _vacancyService.UpdateVacancyAsync(id, vacancyDto);
            if (updatedVacancy == null)
            {
                return NotFound();
            }

            return Ok(updatedVacancy);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteVacancy(Guid id)
        {
            var vacancyIsRemoved = await _vacancyService.DeleteVacancyAsync(id);
            if (!vacancyIsRemoved)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}