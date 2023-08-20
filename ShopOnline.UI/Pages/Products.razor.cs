using Microsoft.AspNetCore.Components;

using ShopOnline.Models.Product;
using ShopOnline.Services.IServices;

namespace ShopOnline.UI.Pages;

public class ProductsBase : ComponentBase
{
    [Inject]
    public IUnitOfServices Services { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }

    public string ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Products = await Services.Products.RetrieveAllProductsAsync();
            var userCartItems = await Services.CartItems.GetUserItemsAsync(HardCoded.UserId);

            var totalQty = userCartItems.Sum(ci => ci.Qty);

            Services.CartItems.RaisEventOnShoppingCartChanged(totalQty);
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected IOrderedEnumerable<IGrouping<int, ProductDto>> GetProductsOrderdByCategoryGroups()
    {
        return from product in Products
               group product by product.CategoryId into prodByCatGroup
               orderby prodByCatGroup.Key
               select prodByCatGroup;
    }
    protected string GetCategoryName(IGrouping<int, ProductDto> productsOrderdByategoryGroup) =>
        productsOrderdByategoryGroup.FirstOrDefault(p => p.CategoryId == productsOrderdByategoryGroup.Key).CategoryName;
}
