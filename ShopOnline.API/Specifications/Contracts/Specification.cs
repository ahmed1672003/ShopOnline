using System.Linq.Expressions;

namespace ShopOnline.API.Specifications.Contracts;

public class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
{
    public Expression<Func<TEntity, bool>>? Criteria { get; }
    public List<Expression<Func<TEntity, object>>> IncludesExpression { get; } = new();
    public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }
    public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }
    public (Func<TEntity, object> property, Expression<Func<TEntity, object>> propertyExpression) ExecuteUpdateRequirments { get; private set; }

    protected void AddInclude
        (Expression<Func<TEntity, object>> includeExpression) => IncludesExpression.Add(includeExpression);
    protected void AddOrderBy
        (Expression<Func<TEntity, object>> orderByExpression) => OrderByExpression = orderByExpression;
    protected void AddOrderByDescending(
        Expression<Func<TEntity, object>> orderByDescendingExpression) => OrderByDescendingExpression = orderByDescendingExpression;
    protected void AddExecuteUpdate
        ((Func<TEntity, object> property,
        Expression<Func<TEntity, object>> propertyExpression) executeUpdateRequirments) =>
        ExecuteUpdateRequirments = executeUpdateRequirments;


}
