namespace ShopOnline.API.Specifications.Carts;

public sealed class IsUserHaveCartSpecification<TEntity> : Specification<TEntity> where TEntity : Cart
{
    public IsUserHaveCartSpecification(int userId) : base(c => c.UserId == userId) { }
}
