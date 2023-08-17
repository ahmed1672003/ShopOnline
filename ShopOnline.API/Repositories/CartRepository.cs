using ShopOnline.API.Data;
using ShopOnline.API.Entities;
using ShopOnline.API.IRepositories;

namespace ShopOnline.API.Repositories;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(IShopOnlineDbContext context) : base(context)
    {
    }
}
