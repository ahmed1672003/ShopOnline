using Microsoft.AspNetCore.Components;

using ShopOnline.Models.Product;
using ShopOnline.Services.IServices;

namespace ShopOnline.UI.Pages;

public partial class ProductsByCategory : ComponentBase
{
    [Parameter]
    public int CategoryId { get; set; }

    public IEnumerable<ProductDto> Products { get; set; }

    [Inject]
    public IUnitOfServices Services { get; set; }

    public string CategoryName { get; set; }

    public string ErrorMessage { get; set; }


    protected override async Task OnParametersSetAsync()
    {
        try
        {
            Products = await Services.Products.RetrieveAllProductsByCategoryId(CategoryId);

            if (Products != null && Products.Count() > 0)
            {
                var productDto = Products.FirstOrDefault(p => p.CategoryId == CategoryId);

                if (productDto != null)
                {
                    CategoryName = productDto.CategoryName;
                }
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

}
