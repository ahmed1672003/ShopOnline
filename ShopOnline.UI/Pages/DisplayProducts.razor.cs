using Microsoft.AspNetCore.Components;

using ShopOnline.Models.Product;

namespace ShopOnline.UI.Pages;

public partial class DisplayProducts : ComponentBase
{
    [Parameter]
    public IEnumerable<ProductDto> Products { get; set; }
}
