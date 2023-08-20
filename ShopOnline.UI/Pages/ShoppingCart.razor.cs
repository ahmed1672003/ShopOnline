using Microsoft.AspNetCore.Components;

using ShopOnline.Services.IServices;

namespace ShopOnline.UI.Pages;

public partial class ShoppingCart
{
    [Inject]
    public IUnitOfServices Services { get; set; }

    public IEnumerable<CartItemDto> CartItems { get; set; }

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
        }
        catch
        {
            NavigationManager.NavigateTo("/NotFound");
        }
    }

    private void RemoveCartItem(int id)
    {
        var cartItemDto = GetCartItem(id);

        CartItems.ToList().Remove(cartItemDto);
    }

    private CartItemDto GetCartItem(int id)
    {
        return CartItems.FirstOrDefault(i => i.Id == id);
    }









    protected Task UpdateCartItemQty_Input(int itemId)
    {
        return Task.CompletedTask;
    }

    protected Task UpdateQtyCartItem_Click(int itemId, int Qty)
    {
        return Task.CompletedTask;
    }

}
