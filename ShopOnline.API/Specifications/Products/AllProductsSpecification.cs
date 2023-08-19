namespace ShopOnline.API.Specifications.Products;

public sealed class AllProductsSpecification<TEntity> : Specification<TEntity> where TEntity : Product
{
    public AllProductsSpecification()
    {
        AddIncludeExpression(p => p.Category);
    }
}
