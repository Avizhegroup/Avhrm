using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Persistence.Services;
public class ProjectService : IProjectService
{
    private readonly AvhrmDbContext dbContext;
    private DbSet<Project> dbSet;
    public ProjectService(AvhrmDbContext dbContext)
    {
        this.dbContext = dbContext;
        dbSet = this.dbContext.Projects;
    }

    public async Task<List<Project>> GetAllProjects(CallContext callContext = default)
    => await dbSet.ToListAsync();
}
