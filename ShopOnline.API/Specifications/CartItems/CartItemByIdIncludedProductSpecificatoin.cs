namespace ShopOnline.API.Specifications.CartItems;

public class CartItemByIdIncludedProductSpecificatoin<TEntity> : Specification<TEntity> where TEntity : CartItem
{
    public CartItemByIdIncludedProductSpecificatoin(int productId, int cartId)
        : base(ci => ci.ProductId == productId && ci.CartId == cartId)
    {
        AddIncludeExpression(ci => ci.Product);
    }
}
