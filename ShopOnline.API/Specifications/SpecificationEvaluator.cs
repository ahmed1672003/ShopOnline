using Microsoft.EntityFrameworkCore;

namespace ShopOnline.API.Specifications;

public class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity>
        (IQueryable<TEntity> inputQueryable,
        ISpecification<TEntity> specification) where TEntity : class
    {
        IQueryable<TEntity> query = inputQueryable;

        if (specification.Criteria is not null)
            query = query.Where(specification.Criteria);


        query = specification.IncludesExpression.Aggregate(
         query,
         (current, includeExpression) =>
         {
             var query = current;

             query = query.Include(includeExpression);

             return query;
         });


        if (specification.OrderByExpression is not null)
            query = query.OrderBy(specification.OrderByExpression);

        if (specification.OrderByDescendingExpression is not null)
            query = query.OrderByDescending(specification.OrderByDescendingExpression);
        return query;
    }
}
