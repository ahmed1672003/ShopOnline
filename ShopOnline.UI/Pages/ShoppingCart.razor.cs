using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using ShopOnline.Services.IServices;

namespace ShopOnline.UI.Pages;

public partial class ShoppingCart
{
    [Inject]
    public IUnitOfServices Services { get; set; }

    [Inject]
    public IJSRuntime JS { get; set; }
    public List<CartItemDto> CartItems { get; set; }

    public string TotalPrice { get; set; }

    public int TotalQty { get; set; }


    //[Parameter]
    //public int UserId { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    public string ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            CartItems = await Services.CartItems.GetUserItemsAsync(HardCoded.UserId);
            CartChanged();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }

    protected async Task DeleteCartItem_Click(int cartItemId)
    {
        try
        {
            var result = await Services.CartItems.DeleteCartItemAsync(cartItemId);

            if (!result)
                NavigationManager.NavigateTo("/NotFound");

            RemoveCartItem(cartItemId);
            CartChanged();
        }
        catch
        {
            NavigationManager.NavigateTo("/NotFound");
        }
    }

    protected async Task UpdateQtyCartItem_Click(int itemId, int Qty)
    {
        if (Qty > 0)
        {
            var returnedUpdatedItem = await Services.CartItems.UpdateCartItemQtyAsync(itemId, new()
            {
                Qty = Qty,
                CartItemId = itemId
            });
            UpdateItemTotalPrice(returnedUpdatedItem);
            CartChanged();
            await MakeUpdateQtyButtonVisible(itemId, false);

        }
        else
        {
            var item = CartItems.FirstOrDefault(c => c.Id == itemId);

            if (item != null)
            {
                item.Qty = 1;
                item.TotalPrice = item.Price;
            }
        }
    }

    protected async Task UpdateCartItemQty_Input(int itemId)
    {
        await MakeUpdateQtyButtonVisible(itemId, true);
    }


    private async Task MakeUpdateQtyButtonVisible(int cartItemId, bool visible)
    {
        await JS.InvokeVoidAsync("MakeUpdateQtyButtonVisible", cartItemId, visible);
    }

    private void RemoveCartItem(int id)
    {
        var cartItemDto = GetCartItem(id);

        CartItems.Remove(cartItemDto);
    }
    private CartItemDto GetCartItem(int id)
    {
        return CartItems.FirstOrDefault(i => i.Id == id);
    }

    private void CalculateCartSummaryTotals()
    {
        SetTotalPrice();
        SetTotalQty();
    }

    private void SetTotalPrice()
    {
        TotalPrice = CartItems.Sum(ci => ci.TotalPrice).ToString("C");
    }

    private void SetTotalQty()
    {
        TotalQty = CartItems.Sum(ci => ci.Qty);
    }
    private void UpdateItemTotalPrice(CartItemDto dto)
    {
        var item = GetCartItem(dto.Id);

        if (item is not null)
        {
            item.TotalPrice = dto.Price * dto.Qty;
        }
    }

    private void CartChanged()
    {
        CalculateCartSummaryTotals();
        Services.CartItems.RaisEventOnShoppingCartChanged(TotalQty);
    }
}
