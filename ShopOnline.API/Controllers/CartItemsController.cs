using Microsoft.AspNetCore.Mvc;

using ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommands;
using ShopOnline.API.Application.Features.CartItems.Queries.CartItemQueries;
using ShopOnline.Models.CartItem;

namespace ShopOnline.API.Controllers;
[Route("api/v1/[controller]/[action]")]
[ApiController]
public class CartItemsController : ShopOnlineController
{
    public CartItemsController(IMediator mediator) : base(mediator) { }

    [HttpPost, ActionName("add-cart-item")]
    public async Task<IActionResult> Post(CartItemToAddDto dto) =>
         NewResult(await Mediator.Send(new CreateCartItemCommand(dto)));

    [HttpPatch, ActionName("update-cart-item-qty")]
    public async Task<IActionResult> UpdateCartItemQty(int? id, CartItemQtyUpdateDto dto) =>
         NewResult(await Mediator.Send(new UpdateCartItemQtyCommand(id, dto)));

    [HttpDelete, ActionName("delete-cart-item-bt-id")]
    public async Task<IActionResult> DeleteCartItemById(int? id) =>
        NewResult(await Mediator.Send(new DeleteCartItemCommand(id)));

    [HttpGet, ActionName("get-user-cart-items")]
    public async Task<IActionResult> RetrieveUserCartItems(int? userId) =>
        NewResult(await Mediator.Send(new RetrieveUserCartItemsQuery(userId)));
}
