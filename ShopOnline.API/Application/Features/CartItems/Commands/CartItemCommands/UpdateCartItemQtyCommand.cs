using ShopOnline.Models.CartItem;

namespace ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommands;

public sealed record UpdateCartItemQtyCommand(int? Id, CartItemQtyUpdateDto Dto) : IRequest<Response<CartItemDto>>;

