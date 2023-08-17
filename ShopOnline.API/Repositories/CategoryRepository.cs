using ShopOnline.API.Data;
using ShopOnline.API.Entities;
using ShopOnline.API.IRepositories;

namespace ShopOnline.API.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(IShopOnlineDbContext context) : base(context)
    {
    }
}
