using ShopOnline.Models.CartItem;

namespace ShopOnline.Services.IServices;
public interface ICartItemService
{
    Task<CartItemDto> AddCartItem(CartItemToAddDto dto);

    Task<bool> UpdateCartItemQty(int id, CartItemQtyUpdateDto dto);

    Task<IEnumerable<CartItemDto>> GetUserItems(int userId);
    Task<CartItemDto> DeleteCartItem(int id);
}
