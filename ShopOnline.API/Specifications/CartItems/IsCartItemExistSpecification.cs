namespace ShopOnline.API.Specifications.CartItems;

public class IsCartItemExistSpecification<TEntity> : Specification<TEntity> where TEntity : CartItem
{
    public IsCartItemExistSpecification(int id) : base(ci => ci.Id == id) { }
}
