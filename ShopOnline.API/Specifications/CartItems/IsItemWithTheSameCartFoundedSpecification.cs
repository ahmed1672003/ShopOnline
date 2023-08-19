namespace ShopOnline.API.Specifications.CartItems;

public class IsItemWithTheSameCartFoundedSpecification<TEntity> : Specification<TEntity> where TEntity : CartItem
{
    public IsItemWithTheSameCartFoundedSpecification(int productId, int cartId)
        : base(ci => ci.ProductId == productId && ci.CartId == cartId)
    {

    }
}
