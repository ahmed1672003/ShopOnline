using ShopOnline.Models.CartItem;

namespace ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommands;
public sealed record DeleteCartItemCommand(int? Id) : IRequest<Response<CartItemDto>>;

