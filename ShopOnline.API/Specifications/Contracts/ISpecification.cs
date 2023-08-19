using System.Linq.Expressions;

namespace ShopOnline.API.Specifications.Contracts;

public interface ISpecification<TEntity> where TEntity : class
{
    Expression<Func<TEntity, bool>> Criteria { get; }
    Expression<Func<TEntity, object>> GroupByExpression { get; }
    List<Expression<Func<TEntity, object>>> IncludesExpression { get; }
    List<string> IncludesString { get; }
    Expression<Func<TEntity, object>> OrderByExpression { get; }
    Expression<Func<TEntity, object>> OrderByDescendingExpression { get; }

    (Func<TEntity, object> PropertyExpression,
    Expression<Func<TEntity, object>> ValueExpression) ExecuteUpdateRequirments
    { get; }

    public (int? pageNumber, int? pageSize) PaginationRequirments { get; }

    bool IsPagingEnabled { get; }
}
