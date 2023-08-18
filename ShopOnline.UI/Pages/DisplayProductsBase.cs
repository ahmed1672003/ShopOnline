using Microsoft.AspNetCore.Components;

using ShopOnline.Models.Product;

namespace ShopOnline.UI.Pages;

public class DisplayProductsBase : ComponentBase
{
    [Parameter]
    public IEnumerable<ProductDto> Products { get; set; }
}
