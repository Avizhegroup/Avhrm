using AutoMapper;
using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Avhrm.Core.Features.WorkChallenge.Query.GetAllWorkChallenge;
using Avhrm.Core.Features.WorkChallenge.Query.GetWorkChallengeByIds;
using Avhrm.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;
using System.Collections.Generic;

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

    public async Task<List<GetAllWorkChallengeVm>> GetAllWorkChallenges(CallContext context = default)
    => mapper.Map<List<GetAllWorkChallengeVm>>(await dbContext.WorkTypes.ToListAsync());

    public List<GetWorkChallengeByIdsVm> GetWorkChallengesByIds(GetWorkChallengeByIdsQuery query, CallContext context = default)
    => mapper.Map<List<GetWorkChallengeByIdsVm>>(dbContext.WorkTypes.Where(p=> query.Ids.Contains(p.Id)).ToListAsync());

}
