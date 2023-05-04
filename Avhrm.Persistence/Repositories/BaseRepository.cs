using Avhrm.Core;
using Avhrm.Core.Common;
using Avhrm.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Avhrm.Persistence.Repositories;

public class BaseRepository<T> : IBaseContract<T> where T : BaseEntity
{
    internal readonly AvhrmDbContext dbContext;
    internal readonly DbSet<T> dbSet;

    public BaseRepository(AvhrmDbContext dbContext)
    {
        this.dbContext = dbContext;

        dbSet = this.dbContext.Set<T>();    
    }

    public async Task<List<T>> GetAllForCurrentUser(CallContext context = default, CancellationToken cancellationToken =new())
    => await dbSet.Where(p => p.CreatorUser == context.GetUserId()).AsNoTracking().ToListAsync(cancellationToken);

    public async Task<bool> InsertInstance(T instance, CallContext context = default, CancellationToken token = new())
    {
        instance.CreateDateTime = DateTime.Now;

        instance.CreatorUser = context.GetUserId();

        await dbSet.AddAsync(instance, token);

        return await dbContext.SaveChangesAsync(token) == 1;
    }

    public async Task<bool> UpdateInstance(T instance, CallContext context = default, CancellationToken token = new())
    {
        instance.LastUpdateDateTime = DateTime.Now;

        instance.LastUpdateUser = context.GetUserId();

        dbSet.Update(instance);

        return await dbContext.SaveChangesAsync(token) == 1;
    }
}
