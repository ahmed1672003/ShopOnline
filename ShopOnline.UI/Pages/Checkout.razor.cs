﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using ShopOnline.Services.IServices;

namespace ShopOnline.UI.Pages;

public partial class Checkout
{
    [Inject]
    public IJSRuntime Js { get; set; }

    protected IEnumerable<CartItemDto> ShoppingCartItems { get; set; }

    protected int TotalQty { get; set; }

    protected string PaymentDescription { get; set; }

    protected decimal PaymentAmount { get; set; }

    [Inject]
    public IUnitOfServices Services { get; set; }

    //[Inject]
    //public IManageCartItemsLocalStorageService ManageCartItemsLocalStorageService { get; set; }


    protected string DisplayButtons { get; set; } = "block";

    protected override async Task OnInitializedAsync()
    {
        try
        {
            //ShoppingCartItems = await ManageCartItemsLocalStorageService.GetCollection();
            ShoppingCartItems = await Services.CartItems.GetUserItemsAsync(HardCoded.UserId);

            if (ShoppingCartItems != null && ShoppingCartItems.Count() > 0)
            {
                Guid orderGuid = Guid.NewGuid();

                PaymentAmount = ShoppingCartItems.Sum(p => p.TotalPrice);
                TotalQty = ShoppingCartItems.Sum(p => p.Qty);
                PaymentDescription = $"O_{HardCoded.UserId}_{orderGuid}";
            }
            else
            {
                DisplayButtons = "none";
            }
        }
        catch (Exception)
        {
            //Log exception
            throw;
        }
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        try
        {
            if (firstRender)
            {
                await Js.InvokeVoidAsync("initPayPalButton");
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}
