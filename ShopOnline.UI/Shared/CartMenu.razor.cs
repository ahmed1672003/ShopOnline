using Microsoft.AspNetCore.Components;

using ShopOnline.Services.IServices;

namespace ShopOnline.UI.Pages;

public partial class CartMenue : ComponentBase, IDisposable
{
    public IUnitOfServices Services { get; set; }

    public int ShoppingCartItemCount { get; set; } = 0;
    protected override void OnInitialized()
    {
        Services.CartItems.OnShoppingCartChanged += ShoppingCartChanged;
    }

    private void ShoppingCartChanged(int totalQty)
    {
        ShoppingCartItemCount = totalQty;
        StateHasChanged();
    }

    public void Dispose()
    {
        Services.CartItems.OnShoppingCartChanged -= ShoppingCartChanged;
    }
}
