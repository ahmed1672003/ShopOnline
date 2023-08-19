using ShopOnline.API.Specifications.Contracts;

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
    Task<int> ExecuteDeleteAsync
        (ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default);
    Task<IQueryable<TEntity>> RetriveAllAsync(
        CancellationToken cancellationToken = default);
    Task<IQueryable<TEntity>> RetriveAllWithSpecificationAsync
        (ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default);

    Task<TEntity> RetriveWithSpecificationAsync
        (ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default);

    Task<bool> IsExistAsync(
        ISpecification<TEntity> specification = null,
        CancellationToken cancellationToken = default);
}
