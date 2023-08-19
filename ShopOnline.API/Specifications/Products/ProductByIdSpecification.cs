namespace ShopOnline.API.Specifications.Products;
public sealed class ProductByIdSpecification<TEntity> : Specification<TEntity> where TEntity : Product
{
    public ProductByIdSpecification(int id) : base(p => p.Id == id)
    {
        AddIncludeExpression(p => p.Category);
    }
}
