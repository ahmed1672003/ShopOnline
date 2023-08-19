namespace ShopOnline.API.Specifications.Carts;

public sealed class UserCartIncludedCartItems<TEntity> : Specification<TEntity> where TEntity : Cart
{
    public UserCartIncludedCartItems(int userId) : base(c => c.UserId == userId)
    {
        AddIncludeExpression(c => c.CartItems);
    }
}
