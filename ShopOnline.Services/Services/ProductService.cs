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
            response = await _httpClient.GetFromJsonAsync<Response<IEnumerable<ProductDto>>>(Urls.Product.RetrieveAllProductsUrl);

            if (response.Data is not null)
                return response.Data;

            return new HashSet<ProductDto>();
        }
        catch
        {
            return Enumerable.Empty<ProductDto>();
        }
    }
}
