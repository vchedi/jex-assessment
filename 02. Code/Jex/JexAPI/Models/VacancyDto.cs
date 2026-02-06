using System.ComponentModel.DataAnnotations;

namespace JexAPI.Models
{
    public class VacancyDto
    {
        public Guid? Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool Published { get; set; }

        [Required]
        public required Guid CompanyId { get; set; }
    }
}