using ShopOnline.API.Specifications.Contracts;

namespace ShopOnline.API.Specifications.Products;
public class ProductByIdSpecification<TEntity> : Specification<TEntity> where TEntity : Product
{
    public ProductByIdSpecification(int id) : base(s => s.Id == id) { }
}
