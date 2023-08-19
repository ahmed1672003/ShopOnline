namespace ShopOnline.API.Specifications.CartItems;

public class DeleteCartItemSpecification<TEntity> : Specification<TEntity> where TEntity : CartItem
{
    public DeleteCartItemSpecification(int id) : base(ci => ci.Id == id)
    {
    }
}
