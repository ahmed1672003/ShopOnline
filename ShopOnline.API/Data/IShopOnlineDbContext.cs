using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ShopOnline.API.Data;

public interface IShopOnlineDbContext
{
    DatabaseFacade Database { get; }
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    ValueTask DisposeAsync();
}
