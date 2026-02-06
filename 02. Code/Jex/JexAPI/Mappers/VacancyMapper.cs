using JexAPI.DataModels;
using JexAPI.Models;

namespace JexAPI.Mappers
{
    public static class VacancyMapper
    {
        public static VacancyDto MapToDto(this Vacancy entity) => new()
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Published = entity.Published,
            CompanyId = entity.CompanyId
        };

        public static Vacancy MapToEntity(this VacancyDto dto) => new()
        {
            Title = dto.Title,
            Description = dto.Description,
            Published = dto.Published,
            CompanyId = dto.CompanyId,
            CreatedDate = DateTime.UtcNow
        };
    }
}