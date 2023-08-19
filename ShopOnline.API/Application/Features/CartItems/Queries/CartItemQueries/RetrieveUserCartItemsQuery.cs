using ShopOnline.Models.CartItem;
namespace ShopOnline.API.Application.Features.CartItems.Queries.CartItemQueries;
public sealed record RetrieveUserCartItemsQuery(int? UserId) : IRequest<Response<IEnumerable<CartItemDto>>>;