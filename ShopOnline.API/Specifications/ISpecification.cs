using System.Linq.Expressions;

namespace ShopOnline.API.Specifications;

public interface ISpecification<TEntity> where TEntity : class
{
    Expression<Func<TEntity, bool>>? Criteria { get; }
    List<Expression<Func<TEntity, object>>> IncludesExpression { get; }
    Expression<Func<TEntity, object>>? OrderByExpression { get; }
    Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; }

    (Func<TEntity, object> PropertyExpression,
        Expression<Func<TEntity, object>> ValueExpression)
        ExecuteUpdateRequirments
    { get; }
}
