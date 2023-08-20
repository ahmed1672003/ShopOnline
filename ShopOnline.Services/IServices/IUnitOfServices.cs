namespace ShopOnline.Services.IServices;

public interface IUnitOfServices
{
    IProductService Products { get; }
    ICartItemService CartItems { get; }
}
