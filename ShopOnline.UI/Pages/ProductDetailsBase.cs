using Microsoft.AspNetCore.Components;

using ShopOnline.Models.Product;
using ShopOnline.Services.IServices;

namespace ShopOnline.UI.Pages;

public class ProductDetailsBase : ComponentBase
{
    [Parameter]
    public int Id { get; set; }

    [Inject]
    public IUnitOfServices Serveices { get; set; }

    public ProductDto Product { get; set; }

    public string ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Product = await Serveices.Products.RetrieveProductByIdAsync(Id);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}
