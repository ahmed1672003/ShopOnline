namespace ShopOnline.API.Specifications.CartItems;

public class CartItemByIdIncludedProductSpecificatoin<TEntity> : Specification<TEntity> where TEntity : CartItem
{
    public CartItemByIdIncludedProductSpecificatoin(int id) : base(ci => ci.Id == id)
    {
        AddIncludeExpression(ci => ci.Product);
    }
}
