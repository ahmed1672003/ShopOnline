using System.Linq.Expressions;

namespace ShopOnline.API.Specifications;

public interface ISpecification<TEntity> where TEntity : class
{
    Expression<Func<TEntity, bool>>? Criteria { get; }
    List<Expression<Func<TEntity, object>>> IncludesExpression { get; }
    Expression<Func<TEntity, object>>? OrderByExpression { get; }
    Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; }

    (Func<TEntity, object> property, Expression<Func<TEntity, object>> propertyExpression)? ExecuteUpdateRequirments { get; }
}
