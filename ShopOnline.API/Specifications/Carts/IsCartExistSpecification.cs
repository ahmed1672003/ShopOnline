namespace ShopOnline.API.Specifications.Carts;

public class IsCartExistSpecification<TEntity> : Specification<TEntity> where TEntity : Cart
{
    public IsCartExistSpecification(int id) : base(c => c.Id == id)
    {

    }
}
