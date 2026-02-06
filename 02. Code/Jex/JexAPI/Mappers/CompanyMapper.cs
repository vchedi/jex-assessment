using JexAPI.DataModels;
using JexAPI.Models;

namespace JexAPI.Mappers
{
    public static class CompanyMapper
    {
        public static CompanyDto MapToDto(this Company entity) => new()
        {
            Id = entity.Id,
            Name = entity.Name ?? string.Empty,
            Street = entity.Street,
            HouseNumber = entity.HouseNumber,
            HouseNumberAdditional = entity.HouseNumberAdditional,
            ZipCode = entity.ZipCode,
            Location = entity.Location
        };

        public static CompanyDto MapToDto(this Company entity, List<VacancyDto> vacancies)
        {
            var dto = entity.MapToDto();
            dto.Vacancies = vacancies;
            return dto;
        }

        public static Company MapToEntity(this CompanyDto dto) => new()
        {
            Name = dto.Name,
            Street = dto.Street,
            HouseNumber = dto.HouseNumber,
            HouseNumberAdditional = dto.HouseNumberAdditional,
            ZipCode = dto.ZipCode,
            Location = dto.Location
        };
    }
}