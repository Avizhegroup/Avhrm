using Avhrm.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Persistence.Services;

public class AvhrmDbContext : DbContext
{
    public AvhrmDbContext(DbContextOptions<AvhrmDbContext> options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<VacationRequest> VacationRequest { get; set; }
}
