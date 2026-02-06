using Microsoft.EntityFrameworkCore;

namespace JexAPI.DataModels;

public partial class JexDbContext : DbContext
{
    public JexDbContext()
    {
    }

    public JexDbContext(DbContextOptions<JexDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())", "DF_Company_Id")
                .HasColumnName("ID");
            entity.Property(e => e.HouseNumber).HasMaxLength(4);
            entity.Property(e => e.HouseNumberAdditional).HasMaxLength(4);
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Street).HasMaxLength(100);
            entity.Property(e => e.ZipCode).HasMaxLength(6);
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.ToTable("Vacancy");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())", "DF_Vacancy_Id")
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Company).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vacancy_Company");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<JexAPI.Models.VacancyDto> VacancyDto { get; set; } = default!;
}
