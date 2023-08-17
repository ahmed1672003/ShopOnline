namespace ShopOnline.API.Specifications;
public class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>(
        IQueryable<TEntity> inputQueryable,
        ISpecification<TEntity> specification) where TEntity : class
    {
        IQueryable<TEntity> query = inputQueryable;

        if (specification.Criteria is not null)
            query = query.Where(specification.Criteria);

        query = specification.IncludesExpression.Aggregate(
                                                            query,
                                                            (current, includeExpression) =>
                             current.Include(includeExpression));

        query = specification.IncludesString.Aggregate(
                                                        query,
                                                        (current, includeString) =>
                             current.Include(includeString));

        if (specification.OrderByExpression is not null)
            query = query.OrderBy(specification.OrderByExpression);

        else if (specification.OrderByDescendingExpression is not null)
            query = query.OrderByDescending(specification.OrderByDescendingExpression);

        if (specification.GroupByExpression is not null)
            query = query.GroupBy(specification.GroupByExpression).SelectMany(x => x);

        if (specification.IsPagingEnabled)
        {
            var pageNumber = specification.PaginationRequirments.pageNumber.HasValue ?
                                specification.PaginationRequirments.pageNumber.Value <= 0 ?
                                1 : specification.PaginationRequirments.pageNumber.Value : 1;

            var pageSize = specification.PaginationRequirments.pageSize.HasValue ?
                             specification.PaginationRequirments.pageSize.Value <= 0 ?
                            10 : specification.PaginationRequirments.pageSize.Value : 10;

            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
        return query;
    }
}
