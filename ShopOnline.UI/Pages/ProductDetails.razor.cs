using Microsoft.AspNetCore.Components;

using ShopOnline.Models.Product;
using ShopOnline.Services.IServices;

namespace ShopOnline.UI.Pages;

public partial class ProductDetails : ComponentBase
{

    [Inject]
    public IUnitOfServices Serveices { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public int Id { get; set; }

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

    protected async Task AddProductToCart_Click(CartItemToAddDto dto)
    {
        try
        {
            var result = await Serveices.CartItems.AddCartItemAsync(dto);
            NavigationManager.NavigateTo("/ShoppingCart");
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}
