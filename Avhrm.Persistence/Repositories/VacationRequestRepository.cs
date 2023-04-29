using Avhrm.Core.Contracts;
using Avhrm.Core.Entities;
using Avhrm.Persistence.Services;
using Microsoft.AspNetCore.Authorization;

namespace Avhrm.Persistence.Repositories;

[Authorize]
public class VacationRequestRepository : BaseRepository<VacationRequest>, IVacationRequest
{
    public VacationRequestRepository(AvhrmDbContext dbContext): base(dbContext)
    {
    }
}
