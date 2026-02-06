using JexAPI.Models;

namespace JexAPI.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyDto>> GetCompaniesAsync();

        Task<CompanyDto?> GetCompanyByIdAsync(Guid id);

        Task<CompanyDto> CreateCompanyAsync(CompanyDto companyDto);

        Task<CompanyDto?> UpdateCompanyAsync(Guid id, CompanyDto companyDto);

        Task<bool> DeleteCompanyAsync(Guid id);

        Task<List<CompanyDto>> GetActiveCompanies();
    }
}