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
    public async Task CreateAsync
        (TEntity entity,
        CancellationToken cancellationToken = default) =>
        await _entities.AddAsync(entity, cancellationToken);

    public Task DeleteAsync
        (TEntity entity,
        CancellationToken cancellationToken = default) =>
        Task.FromResult(_entities.Remove(entity));

    public async Task<int> ExecuteDeleteAsync
        (ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default) =>
        specification.Criteria is null ?
        await _entities.ExecuteDeleteAsync(cancellationToken) :
        await _entities.Where(specification.Criteria).ExecuteDeleteAsync(cancellationToken);

    public Task ExecuteUpdateAsync
        (ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default)
    {

    }
    public Task UpdateAsync
        (TEntity entity,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
