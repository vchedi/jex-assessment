using JexAPI.DataModels;
using JexAPI.Mappers;
using JexAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JexAPI.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly JexDbContext _dbContext;

        public VacancyService(JexDbContext jexDbContext)
        {
            _dbContext = jexDbContext;
        }

        public async Task<List<VacancyDto>> GetVacanciesAsync(bool? published)
        {
            var query = _dbContext.Vacancies.AsNoTracking();

            if (published.HasValue)
            {
                query = query.Where(vacancy => vacancy.Published == published);
            }

            return await query
                          .Select(vacancy => vacancy.MapToDto())
                          .ToListAsync();
        }

        public async Task<VacancyDto?> GetVacancyByIdAsync(Guid id)
        {
            var vacancy = await _dbContext.Vacancies
                           .AsNoTracking()
                           .FirstOrDefaultAsync(vacancy => vacancy.Id == id);

            return vacancy?.MapToDto();
        }

        public async Task<VacancyDto> CreateVacancyAsync(VacancyDto vacancyDto)
        {
            var entity = vacancyDto.MapToEntity();

            _dbContext.Vacancies.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity.MapToDto();
        }

        public async Task<VacancyDto?> UpdateVacancyAsync(Guid id, VacancyDto vacancyDto)
        {
            var vacancy = await _dbContext.Vacancies.FirstOrDefaultAsync(v => v.Id == id);
            if (vacancy == null)
            {
                return null;
            }

            //Update
            vacancy.Title = vacancyDto.Title;
            vacancy.Description = vacancyDto.Description;
            vacancy.Published = vacancyDto.Published;
            vacancy.CompanyId = vacancyDto.CompanyId;

            await _dbContext.SaveChangesAsync();

            return vacancy.MapToDto();
        }

        public async Task<bool> DeleteVacancyAsync(Guid id)
        {
            var vacancy = await _dbContext.Vacancies.FindAsync(id);
            if (vacancy == null)
            {
                return false;
            }

            _dbContext.Vacancies.Remove(vacancy);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
