using JexAPI.Models;

namespace JexAPI.Services
{
    public interface IVacancyService
    {
        Task<List<VacancyDto>> GetVacanciesAsync(bool? published);

        Task<VacancyDto?> GetVacancyByIdAsync(Guid id);

        Task<VacancyDto> CreateVacancyAsync(VacancyDto dto);

        Task<VacancyDto?> UpdateVacancyAsync(Guid id, VacancyDto vacancyDto);

        Task<bool> DeleteVacancyAsync(Guid id);
    }
}