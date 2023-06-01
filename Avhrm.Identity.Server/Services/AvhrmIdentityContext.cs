using Avhrm.Identity.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Identity.Server.Services;

public class AvhrmIdentityContext : IdentityDbContext<ApplicationUser>
{
    public AvhrmIdentityContext()
    {
    }

    public AvhrmIdentityContext(DbContextOptions<AvhrmIdentityContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
