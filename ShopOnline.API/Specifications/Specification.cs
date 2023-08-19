using System.Linq.Expressions;
using ShopOnline.API.Specifications.Contracts;

namespace ShopOnline.API.Specifications;

public class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
{
    public Specification(Expression<Func<TEntity, bool>> criteria) =>
        Criteria = criteria;
    public Specification() { }

    public Expression<Func<TEntity, bool>> Criteria { get; }

    public Expression<Func<TEntity, object>> GroupByExpression { get; private set; }

    public List<Expression<Func<TEntity, object>>> IncludesExpression { get; } = new();

    public List<string> IncludesString { get; } = new();

    public Expression<Func<TEntity, object>> OrderByExpression { get; private set; }

    public Expression<Func<TEntity, object>> OrderByDescendingExpression { get; private set; }

    public (Func<TEntity, object> PropertyExpression, Expression<Func<TEntity, object>> ValueExpression) ExecuteUpdateRequirments { get; private set; }

    public bool IsPagingEnabled { get; private set; }

    public (int? pageNumber, int? pageSize) PaginationRequirments { get; private set; }

    protected virtual void AddIncludeExpression(
                           Expression<Func<TEntity, object>> includeExpression) =>
        IncludesExpression.Add(includeExpression);
    protected virtual void AddIncludeString(
                           string includesString) =>
        IncludesString.Add(includesString);
    protected virtual void AddOrderBy(
                           Expression<Func<TEntity, object>> orderByExpression) =>
        OrderByExpression = orderByExpression;
    protected virtual void AddOrderByDescending(
                           Expression<Func<TEntity, object>> orderByDescendingExpression) =>
        OrderByDescendingExpression = orderByDescendingExpression;
    protected virtual void AddExecuteUpdate(
                           (Func<TEntity, object> property,
                           Expression<Func<TEntity, object>> propertyExpression) executeUpdateRequirments) =>
        ExecuteUpdateRequirments = executeUpdateRequirments;
    protected virtual void ApplyPaging(
                                      (int? pageNumber, int? pageSize) paginationRequirments)
    {
        PaginationRequirments = paginationRequirments;
        IsPagingEnabled = true;
    }
    protected virtual void ApplyGroupBy(
                           Expression<Func<TEntity, object>> groupByExpression) =>
        GroupByExpression = groupByExpression;
}
