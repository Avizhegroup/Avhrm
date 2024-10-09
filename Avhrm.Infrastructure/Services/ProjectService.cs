using AutoMapper;
using Avhrm.Application.Contracts;
using Avhrm.Application.Features.Project.Query.GetAllProjects;
using Avhrm.Application.Features.WorkType.Query.GetAllWorkTypes;
using Avhrm.Domains;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Infrastructure.Services;
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

    public async Task<List<GetAllProjectsVm>> GetAllProjects(CallContext callContext = default)
    => mapper.Map<List<GetAllProjectsVm>>(await dbSet.ToListAsync());
}
