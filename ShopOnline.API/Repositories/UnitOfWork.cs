using Microsoft.EntityFrameworkCore.Storage;

namespace ShopOnline.API.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(
        ICartItemRepository cartItems,
        ICartRepository carts,
        ICategoryRepository categories,
        IProductRepository products,
        IUserRepository users,
        IShopOnlineDbContext context)
    {
        CartItems = cartItems;
        Carts = carts;
        Categories = categories;
        Products = products;
        Users = users;
        Context = context;
    }

    public ICartItemRepository CartItems { get; private set; }
    public ICartRepository Carts { get; private set; }
    public ICategoryRepository Categories { get; private set; }
    public IProductRepository Products { get; private set; }
    public IUserRepository Users { get; private set; }
    public IShopOnlineDbContext Context { get; private set; }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) =>
        await Context.Database.BeginTransactionAsync(cancellationToken);

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default) =>
    await Context.Database.CommitTransactionAsync(cancellationToken);

    public async ValueTask DisposeAsync() =>
        await Context.DisposeAsync();

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default) =>
    await Context.Database.RollbackTransactionAsync(cancellationToken);
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await Context.SaveChangesAsync(cancellationToken);

}
