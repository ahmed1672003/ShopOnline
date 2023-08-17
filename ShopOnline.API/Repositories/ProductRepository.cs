using ShopOnline.API.Data;
using ShopOnline.API.Entities;
using ShopOnline.API.IRepositories;

namespace ShopOnline.API.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(IShopOnlineDbContext context) : base(context)
    {
    }
}
