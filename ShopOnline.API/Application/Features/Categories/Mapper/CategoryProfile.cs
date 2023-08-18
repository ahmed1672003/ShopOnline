using ShopOnline.Models.Category;

namespace ShopOnline.API.Application.Features.Categories.Mapper;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        Mapp();
    }
    void Mapp()
    {
        CreateMap<Category, CategoryDto>();
    }
}
