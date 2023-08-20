namespace ShopOnline.API.Specifications.Products;

public class AllProductsByCategoryIdSpecification<TEntity> : Specification<TEntity> where TEntity : Product
{
    public AllProductsByCategoryIdSpecification(int categoryId)
        : base(p => p.CategoryId == categoryId)
    {
        AddIncludeExpression(p => p.Category);
    }
}
