namespace JexAPI.DataModels;

public partial class Vacancy
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool Published { get; set; }

    public Guid CompanyId { get; set; }

    public virtual Company Company { get; set; } = null!;
}
