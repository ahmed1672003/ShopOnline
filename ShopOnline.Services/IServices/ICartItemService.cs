using ShopOnline.Models.CartItem;

namespace ShopOnline.Services.IServices;
public interface ICartItemService
{
    Task<CartItemDto> AddCartItemAsync(CartItemToAddDto dto);

    Task<CartItemDto> UpdateCartItemQtyAsync(int id, CartItemQtyUpdateDto dto);

    Task<List<CartItemDto>> GetUserItemsAsync(int userId);
    Task<bool> DeleteCartItemAsync(int id);
}
