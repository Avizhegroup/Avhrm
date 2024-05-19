using AutoMapper;
using Avhrm.Core.Contracts;
using Avhrm.Core.Features.WorkType.Query.GetAllWorkTypes;
using Avhrm.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Persistence.Services;

[Authorize]
public class WorkTypeService : IWorkTypeService
{
    private readonly AvhrmDbContext dbContext;
    private readonly IMapper mapper;
    private readonly DbSet<WorkType> dbSet;
    public WorkTypeService(AvhrmDbContext dbContext
        , IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
        dbSet = dbContext.WorkTypes;
    }

    public async Task<List<GetAllWorkTypesVm>> GetWorkTypesByDepartmentId(CallContext context = default)
    => mapper.Map<List<GetAllWorkTypesVm>>(await dbContext.WorkTypes.Where(p=>p.DepartmentId == context.GetDepartmentId()).ToListAsync());
}
