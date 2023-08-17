using ShopOnline.API.Data;
using ShopOnline.API.Entities;
using ShopOnline.API.IRepositories;

namespace ShopOnline.API.Repositories;

public class CartItemRepository : Repository<CartItem>, ICartItemRepository
{
    public CartItemRepository(IShopOnlineDbContext context) : base(context)
    {
    }
}
