using ShopOnline.Models.Product;

namespace ShopOnline.Services.IServices;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> RetrieveAllProductsAsync();
}
