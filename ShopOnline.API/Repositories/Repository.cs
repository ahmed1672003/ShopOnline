using ShopOnline.API.Specifications.Contracts;

namespace ShopOnline.API.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly IShopOnlineDbContext _context;
    private readonly DbSet<TEntity> _entities;
    public Repository(IShopOnlineDbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    #region Commands
    public async Task CreateAsync
                      (TEntity entity,
                      CancellationToken cancellationToken = default) =>
   await _entities.AddAsync(entity, cancellationToken);
    public Task UpdateAsync
                (TEntity entity,
                CancellationToken cancellationToken = default) =>
        Task.FromResult(_entities.Update(entity));

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

    public async Task<int> ExecuteUpdateAsync
                           (ISpecification<TEntity> specification,
                           CancellationToken cancellationToken = default)
    {
        if (specification.Criteria is null)
            return await _entities.ExecuteUpdateAsync(entity =>
             entity.SetProperty(
                 specification.ExecuteUpdateRequirments.PropertyExpression,
                 specification.ExecuteUpdateRequirments.ValueExpression),
                 cancellationToken);
        else
            return await _entities
                   .Where(specification.Criteria)
                   .ExecuteUpdateAsync(entity =>
             entity.SetProperty(
                 specification.ExecuteUpdateRequirments.PropertyExpression,
                 specification.ExecuteUpdateRequirments.ValueExpression),
                 cancellationToken);
    }

    #endregion

    #region Queries
    public async Task<TEntity> RetriveWithSpecificationAsync(
        ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default) =>
        await SpecificationEvaluator.GetQuery(_entities, specification).FirstOrDefaultAsync();

    public Task<IQueryable<TEntity>> RetriveAllAsync(
                                     CancellationToken cancellationToken = default) =>
                Task.FromResult(_entities.AsQueryable());
    public Task<IQueryable<TEntity>> RetriveAllWithSpecificationAsync
                                     (ISpecification<TEntity> specification,
                                      CancellationToken cancellationToken = default)
    {
        var query = SpecificationEvaluator.GetQuery(_entities, specification);

        return Task.FromResult(query);
    }
    public async Task<bool> IsExistAsync(
        ISpecification<TEntity> specification = null,
        CancellationToken cancellationToken = default)
    {
        if (specification is null)
            return await _entities.AnyAsync();
        else
            return await _entities.AnyAsync(specification.Criteria!, cancellationToken);
    }
    #endregion
}
