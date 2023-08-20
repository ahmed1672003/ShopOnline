using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

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

    public async Task<CartItemDto> AddCartItemAsync(CartItemToAddDto dto)
    {
        var response = new Response<CartItemDto>();
        try
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var result = await _httpClient.PostAsJsonAsync(Urls.CartItems.AddCartItemUrl, dto);

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
    public async Task<List<CartItemDto>> GetUserItemsAsync(int userId)
    {
        var response = new Response<List<CartItemDto>>();
        try
        {
            var result = await _httpClient.GetAsync($"{Urls.CartItems.GetUserItemsUrl}{userId}");

            if (!result.IsSuccessStatusCode)
                throw new Exception(await result.Content.ReadAsStringAsync());

            response = await result.Content.ReadFromJsonAsync<Response<List<CartItemDto>>>();
            if (response.IsSucceeded && response.Data is not null)
                return response.Data;

            return new List<CartItemDto>();
        }
        catch
        {
            return null;
        }
    }
    public async Task<bool> DeleteCartItemAsync(int id)
    {
        var response = new Response<CartItemDto>();
        try
        {
            var result = await _httpClient.DeleteAsync($"{Urls.CartItems.DeleteCartItemUrl}{id}");

            if (!result.IsSuccessStatusCode)
                throw new Exception(await result.Content.ReadAsStringAsync());

            response = await result.Content.ReadFromJsonAsync<Response<CartItemDto>>();

            if (response.IsSucceeded)
                return true;

            return false;

        }
        catch (Exception)
        {
            return default;
        }
    }
    public async Task<CartItemDto> UpdateCartItemQtyAsync(int id, CartItemQtyUpdateDto dto)
    {
        var respone = new Response<CartItemDto>();

        try
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _httpClient.PatchAsync($"{Urls.CartItems.UpdateCartItemQtyUrl}{id}", content);

            if (!result.IsSuccessStatusCode)
                throw new Exception(await result.Content.ReadAsStringAsync());

            respone = await result.Content.ReadFromJsonAsync<Response<CartItemDto>>();

            if (respone.IsSucceeded && respone.Data is not null)
                return respone.Data;

            return null;
        }
        catch
        {

            return null;
        }
    }
}
