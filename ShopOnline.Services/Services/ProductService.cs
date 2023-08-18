using System.Net.Http.Json;

using ShopOnline.API.Application.Responses;
using ShopOnline.Models.Product;
using ShopOnline.Services.Constants;
using ShopOnline.Services.IServices;

namespace ShopOnline.Services.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<ProductDto>> RetrieveAllProductsAsync()
    {
        var response = new Response<IEnumerable<ProductDto>>();
        try
        {
            var result = await _httpClient.GetAsync(Urls.Product.RetrieveAllProductsUrl);

            if (!result.IsSuccessStatusCode)
                return new HashSet<ProductDto>();

            response = await result.Content.ReadFromJsonAsync<Response<IEnumerable<ProductDto>>>();

            if (response.Data is not null)
                return response.Data;

            return new HashSet<ProductDto>();
        }
        catch
        {
            return Enumerable.Empty<ProductDto>();
        }
    }

    public async Task<ProductDto> RetrieveProductByIdAsync(int id)
    {
        var response = new Response<ProductDto>();

        var result = await _httpClient.GetAsync($"{Urls.Product.RetrieveProductByIdUrl}{id}");

        if (!result.IsSuccessStatusCode)
        {
            var message = await result.Content.ReadAsStringAsync();
            throw new Exception(message);
        }

        response = await result.Content.ReadFromJsonAsync<Response<ProductDto>>();

        if (response.Data is not null)
            return response.Data;

        return default(ProductDto);

    }
}
