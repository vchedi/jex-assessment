using JexAPI.DataModels;
using JexAPI.Mappers;
using JexAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JexAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly JexDbContext _dbContext;

        public CompanyService(JexDbContext jexDbContext)
        {
            _dbContext = jexDbContext;
        }

        public async Task<List<CompanyDto>> GetCompaniesAsync()
        {
            var companies = await _dbContext.Companies
                                    .AsNoTracking()
                                    .Select(company => company.MapToDto())
                                    .ToListAsync();

            return companies;
        }

        public async Task<CompanyDto?> GetCompanyByIdAsync(Guid id)
        {
            var company = await _dbContext.Companies
                            .AsNoTracking()
                            .FirstOrDefaultAsync(Company => Company.Id == id);

            return company?.MapToDto();
        }

        public async Task<CompanyDto> CreateCompanyAsync(CompanyDto companyDto)
        {
            var entity = companyDto.MapToEntity();

            _dbContext.Companies.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.MapToDto();
        }

        public async Task<CompanyDto?> UpdateCompanyAsync(Guid id, CompanyDto companyDto)
        {
            var company = await _dbContext.Companies.FirstOrDefaultAsync(company => company.Id == id);
            if (company == null)
            {
                return null;
            }

            //Update
            company.Name = companyDto.Name;
            company.Street = companyDto.Street;
            company.HouseNumber = companyDto.HouseNumber;
            company.ZipCode = companyDto.ZipCode;
            company.Location = companyDto.Location;

            await _dbContext.SaveChangesAsync();

            return company.MapToDto();
        }

        public async Task<bool> DeleteCompanyAsync(Guid id)
        {
            var company = await _dbContext.Companies.FindAsync(id);
            if (company == null)
            {
                return false;
            }

            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<CompanyDto>> GetActiveCompanies()
        {
            var companies = _dbContext.Companies;
            var vacancies = _dbContext.Vacancies;

            //Get list of companies that at least have 1 vacancy published
            return await companies
                            .AsNoTracking()
                            .Where(company => vacancies
                                                .Any(x => x.CompanyId == company.Id && x.Published))
                            .Select(vacancy => vacancy.MapToDto())
                            .ToListAsync();
        }
    }
}