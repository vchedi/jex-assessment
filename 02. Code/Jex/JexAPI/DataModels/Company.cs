namespace JexAPI.DataModels;

public partial class Company
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Street { get; set; }

    public string? HouseNumber { get; set; }

    public string? HouseNumberAdditional { get; set; }

    public string? ZipCode { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
}
