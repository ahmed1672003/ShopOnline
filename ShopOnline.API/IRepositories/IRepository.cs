using ShopOnline.API.Specifications;

namespace ShopOnline.API.IRepositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task CreateAsync
        (TEntity entity,
        CancellationToken cancellation = default);
    Task UpdateAsync
        (TEntity entity,
        CancellationToken cancellationToken = default);
    Task DeleteAsync
        (TEntity entity,
        CancellationToken cancellationToken = default);
    Task<int> ExecuteUpdateAsync
        (ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default);
    Task ExecuteDeleteAsync
        (ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default);
}
