using System.Net.Http.Json;

using ShopOnline.API.Application.Responses;
using ShopOnline.Models.CartItem;
using ShopOnline.Services.Constants;
using ShopOnline.Services.IServices;

namespace ShopOnline.Services.Services;
public class CartItemService : ICartItemService
{
    private readonly HttpClient _httpClient;

    public CartItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CartItemDto> AddCartItem(CartItemToAddDto dto)
    {
        var response = new Response<CartItemDto>();
        try
        {
            var result = await _httpClient.PostAsJsonAsync(Urls.CartItems.AddCartItem, dto);

            if (!result.IsSuccessStatusCode)
                throw new Exception(await result.Content.ReadAsStringAsync());

            response = await result.Content.ReadFromJsonAsync<Response<CartItemDto>>();

            if (response.IsSucceeded && response.Data is not null)
                return response.Data;

            return new CartItemDto();

        }
        catch
        {
            return default(CartItemDto);
        }
    }
    public async Task<IEnumerable<CartItemDto>> GetUserItems(int userId)
    {
        var response = new Response<IEnumerable<CartItemDto>>();
        try
        {
            var result = await _httpClient.GetAsync($"{Urls.CartItems.GetUserItems}{userId}");

            if (!result.IsSuccessStatusCode)
                throw new Exception(await result.Content.ReadAsStringAsync());

            response = await result.Content.ReadFromJsonAsync<Response<IEnumerable<CartItemDto>>>();
            if (response.IsSucceeded && response.Data is not null)
                return response.Data;

            return new HashSet<CartItemDto>();
        }
        catch
        {
            return Enumerable.Empty<CartItemDto>();
        }
    }
    public async Task<bool> DeleteCartItem(int id)
    {
        var response = new Response<CartItemDto>();
        try
        {
            var result = await _httpClient.DeleteAsync($"{Urls.CartItems.DeleteCartItem}{id}");

            if (!result.IsSuccessStatusCode)
                throw new Exception(await result.Content.ReadAsStringAsync());

            response = await result.Content.ReadFromJsonAsync<Response<CartItemDto>>();

            if (response.IsSucceeded)


        }
        catch (Exception)
        {
            return default;
        }
    }
    public Task<CartItemDto> UpdateCartItemQty(int id, CartItemQtyUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
