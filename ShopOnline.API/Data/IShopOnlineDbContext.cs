using Microsoft.EntityFrameworkCore;

namespace ShopOnline.API.Data;

public interface IShopOnlineDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
