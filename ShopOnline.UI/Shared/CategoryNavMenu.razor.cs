using Microsoft.AspNetCore.Components;

using ShopOnline.Models.Category;
using ShopOnline.Services.IServices;

namespace ShopOnline.UI.Shared;

public partial class CategoryNavMenu : ComponentBase
{
    [Parameter]
    public int CategoryId { get; set; }
    [Inject]
    public IUnitOfServices Services { get; set; }

    public List<CategoryDto> Categories { get; set; }

    public string ErrorMessage { get; set; }

    //[Inject]
    //public IManageProductsLocalStorageService ManageProductsLocalStorageService { get; set; }

    //public IEnumerable<ProductDto> Products { get; set; }
    //public string CategoryName { get; set; }
    //public string ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Categories = await Services.Categories.RetrieveAllCategoriesAsync();
        }
        catch (Exception ex)
        {

            ErrorMessage = ex.Message;
        }
    }

    //protected override async Task OnParametersSetAsync()
    //{
    //    try
    //    {
    //        Products = await GetProductCollectionByCategoryId(CategoryId);

    //        if (Products != null && Products.Count() > 0)
    //        {
    //            var productDto = Products.FirstOrDefault(p => p.CategoryId == CategoryId);

    //            if (productDto != null)
    //            {
    //                CategoryName = productDto.CategoryName;
    //            }

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrorMessage = ex.Message;
    //    }
    //}

    //private async Task<IEnumerable<ProductDto>> GetProductCollectionByCategoryId(int categoryId)
    //{
    //    var productCollection = await ManageProductsLocalStorageService.GetCollection();

    //    if (productCollection != null)
    //    {
    //        return productCollection.Where(p => p.CategoryId == categoryId);
    //    }
    //    else
    //    {
    //        return await ProductService.GetItemsByCategory(categoryId);
    //    }

    //}

}

