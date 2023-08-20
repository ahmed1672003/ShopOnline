using System.Net.Http.Json;

using ShopOnline.API.Application.Responses;
using ShopOnline.Models.Category;
using ShopOnline.Services.Constants;
using ShopOnline.Services.IServices;

namespace ShopOnline.Services.Services;
public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<CategoryDto>> RetrieveAllCategoriesAsync()
    {
        var response = new Response<List<CategoryDto>>();
        try
        {
            var result = await _httpClient.GetAsync(Urls.Categories.RetrieveAllCategoriesUrl);

            if (!result.IsSuccessStatusCode)
            {
                var message = await result.Content.ReadAsStringAsync();
                throw new Exception(message);
            }

            response = await result.Content.ReadFromJsonAsync<Response<List<CategoryDto>>>();

            if (response.Data is not null)
                return response.Data;

            return new List<CategoryDto>();
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
