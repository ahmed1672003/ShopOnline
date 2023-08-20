using ShopOnline.Models.Product;

namespace ShopOnline.Services.IServices;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> RetrieveAllProductsAsync();
    Task<ProductDto> RetrieveProductByIdAsync(int id);

    Task<IEnumerable<ProductDto>> RetrieveAllProductsByCategoryId(int categoryId);
}
