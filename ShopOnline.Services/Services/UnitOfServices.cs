using ShopOnline.Services.IServices;

namespace ShopOnline.Services.Services;

public class UnitOfServices : IUnitOfServices
{
    public IProductService Products { get; }
    public ICartItemService CartItems { get; }
    public ICategoryService Categories { get; }

    public UnitOfServices(IProductService products, ICartItemService cartItem, ICategoryService categories)
    {
        Products = products;
        CartItems = cartItem;
        Categories = categories;
    }
}
