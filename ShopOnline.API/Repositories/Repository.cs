using Microsoft.EntityFrameworkCore;

using ShopOnline.API.Data;
using ShopOnline.API.IRepositories;
using ShopOnline.API.Specifications;

namespace ShopOnline.API.Repositories;
public class Repository<TEntity> : IRepository<TEntity>> where TEntity : class
{
    private readonly IShopOnlineDbContext _context;
    private readonly DbSet<TEntity> _entities;
    public Repository(IShopOnlineDbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }
    public Task CreateAsync
        (TEntity entity,
        CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }
    public Task DeleteAsync
        (TEntity entity,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task ExecuteDeleteAsync
        (ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task ExecuteUpdateAsync
        (ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task UpdateAsync
        (TEntity entity,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
