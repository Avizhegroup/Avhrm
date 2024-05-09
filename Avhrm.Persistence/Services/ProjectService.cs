using AutoMapper;
using Avhrm.Core.Contracts;
using Avhrm.Core.Features.WorkType.Query.GetAllWorkTypes;
using Avhrm.Domains;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Persistence.Services;
public class ProjectService : IProjectService
{
    private readonly AvhrmDbContext dbContext;
    private readonly IMapper mapper;
    private DbSet<Project> dbSet;
    public ProjectService(AvhrmDbContext dbContext
        , IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        dbSet = this.dbContext.Projects;
    }

    public async Task<List<GetAllWorkTypesVm>> GetAllProjects(CallContext callContext = default)
    => mapper.Map<List<GetAllWorkTypesVm>>(await dbSet.ToListAsync());
}
