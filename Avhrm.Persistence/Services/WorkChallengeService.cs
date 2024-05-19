using AutoMapper;
using Avhrm.Core.Contracts;
using Avhrm.Core.Features.WorkChallenge.Query.GetAllWorkChallenge;
using Avhrm.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Persistence.Services;

[Authorize]
public class WorkChallengeService : IWorkChallengeService
{
    private readonly AvhrmDbContext dbContext;
    private readonly IMapper mapper;
    private readonly DbSet<WorkChallenge> dbSet;
    public WorkChallengeService(AvhrmDbContext dbContext
        , IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        dbSet = dbContext.WorkChallenges;
    }

    public async Task<List<GetAllWorkChallengeVm>> GetWorkChallengesByDepartmentId(CallContext context = default) 
    => mapper.Map<List<GetAllWorkChallengeVm>>(await dbSet.Where(p => p.DepartmentId == context.GetDepartmentId()).ToListAsync());
}
