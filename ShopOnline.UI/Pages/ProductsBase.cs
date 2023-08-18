using Microsoft.AspNetCore.Components;

using ShopOnline.Models.Product;
using ShopOnline.Services.IServices;

namespace ShopOnline.UI.Pages;

public class ProductsBase : ComponentBase
{
    [Inject]
    public IUnitOfServices Context { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Products = await Context.Products.RetrieveAllProductsAsync();
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
