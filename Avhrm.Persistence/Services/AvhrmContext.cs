using Avhrm.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Persistence.Services;

public class AvhrmDbContext : IdentityDbContext<ApplicationUser>
{
    public AvhrmDbContext()
    {
        Database.Migrate();
    }

    public AvhrmDbContext(DbContextOptions<AvhrmDbContext> options) : base(options)
    {
        Database.Migrate();
    }
  
    public DbSet<VacationRequest> VacationRequests { get; set; }
    public DbSet<WorkReport> WorkingReports { get; set; }
    public DbSet<WorkType> WorkTypes { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<WorkChallenge> WorkChallenges { get; set; }
    public DbSet<UserPointChangeLog> PointChangeLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Project).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
