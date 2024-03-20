using Avhrm.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Persistence.Services;

public class AvhrmDbContext : DbContext
{
    public AvhrmDbContext(DbContextOptions<AvhrmDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<VacationRequest> VacationRequests { get; set; }
    public DbSet<WorkReport> WorkingReports { get; set; }
    public DbSet<WorkType> WorkTypes { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Project).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
