using JexAPI.Models;
using JexAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JexAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companies = await _companyService.GetCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "GetCompanyById")]
        public async Task<ActionResult<CompanyDto>> GetCompanyByIdAsync(Guid id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);

            return company == null
                        ? NotFound()
                        : Ok(company);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CompanyDto>> UpdateCompany(Guid id, [FromBody] CompanyDto companyDto)
        {
            var updatedCompany = await _companyService.UpdateCompanyAsync(id, companyDto);
            if (updatedCompany == null)
            {
                return NotFound();
            }

            return Ok(updatedCompany);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> CreateCompany([FromBody] CompanyDto companyDto)
        {
            var newCompany = await _companyService.CreateCompanyAsync(companyDto);

            return CreatedAtAction("GetCompanyById",
                                    new { id = newCompany.Id },
                                    newCompany);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            var companyIsRemoved = await _companyService.DeleteCompanyAsync(id);
            if (!companyIsRemoved)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("active-companies")]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetActiveCompanies()
        {
            var companies = await _companyService.GetActiveCompanies();
            return Ok(companies);
        }
    }
}