namespace ShopOnline.API.Specifications.Products;

public class IsProductExistSpecification<TEntity> : Specification<TEntity> where TEntity : Product
{
    public IsProductExistSpecification(int id) : base(p => p.Id == id) { }
}
