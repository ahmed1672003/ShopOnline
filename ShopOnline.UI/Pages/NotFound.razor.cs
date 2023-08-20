using Microsoft.AspNetCore.Components;

namespace ShopOnline.UI.Pages;

public partial class NotFound : ComponentBase
{
    [Parameter]
    public string ErrorMessage { get; set; }

}
