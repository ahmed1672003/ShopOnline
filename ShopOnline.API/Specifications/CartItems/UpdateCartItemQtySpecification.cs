namespace ShopOnline.API.Specifications.CartItems;

public class UpdateCartItemQtySpecification<TEntity> : Specification<TEntity> where TEntity : CartItem
{
    public UpdateCartItemQtySpecification(int cartId)
        : base(ci => ci.Id == cartId)
    {

    }
}
