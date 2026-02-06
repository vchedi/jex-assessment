using System.ComponentModel.DataAnnotations;

namespace JexAPI.Models
{
    public class CompanyDto
    {
        public Guid? Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(100)]
        public string? Street { get; set; }

        [MaxLength(4)]
        public string? HouseNumber { get; set; }

        [MaxLength(4)]
        public string? HouseNumberAdditional { get; set; }

        [MaxLength(6)]
        public string? ZipCode { get; set; }

        [MaxLength(100)]
        public string? Location { get; set; }

        public List<VacancyDto> Vacancies { get; set; } = [];
    }
}