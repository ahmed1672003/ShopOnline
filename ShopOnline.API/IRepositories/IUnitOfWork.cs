using Microsoft.EntityFrameworkCore.Storage;

using ShopOnline.API.Data;

namespace ShopOnline.API.IRepositories;

public interface IUnitOfWork : IAsyncDisposable
{
    IShopOnlineDbContext Context { get; }
    ICartItemRepository CartItems { get; }
    ICartRepository Carts { get; }
    ICategoryRepository Categories { get; }
    IProductRepository Products { get; }
    IUserRepository Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

}
