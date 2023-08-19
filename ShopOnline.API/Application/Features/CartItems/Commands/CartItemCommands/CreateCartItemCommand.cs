using ShopOnline.Models.CartItem;
namespace ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommands;
public sealed record CreateCartItemCommand(CartItemToAddDto Dto) : IRequest<Response<CartItemDto>>;

