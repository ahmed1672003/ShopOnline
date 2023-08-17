using ShopOnline.API.Data;
using ShopOnline.API.Entities;
using ShopOnline.API.IRepositories;

namespace ShopOnline.API.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(IShopOnlineDbContext context) : base(context)
    {
    }
}
