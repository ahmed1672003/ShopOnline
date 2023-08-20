using ShopOnline.Services.IServices;

namespace ShopOnline.Services.Services;

public class UnitOfServices : IUnitOfServices
{
    public IProductService Products { get; private set; }
    public ICartItemService CartItems { get; private set; }

    public UnitOfServices(IProductService products, ICartItemService cartItem)
    {
        Products = products;
        CartItems = cartItem;
    }
}
