using Microsoft.AspNetCore.Components;

namespace ShopOnline.UI.Pages;

public class NotFoundBase : ComponentBase
{
    [Parameter]
    public string ErrorMessage { get; set; }

}
