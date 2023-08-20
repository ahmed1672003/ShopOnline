using ShopOnline.Models.Category;

namespace ShopOnline.Services.IServices;
public interface ICategoryService

{
    Task<List<CategoryDto>> RetrieveAllCategoriesAsync();
}
