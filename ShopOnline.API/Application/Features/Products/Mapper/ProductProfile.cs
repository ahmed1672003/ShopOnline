namespace ShopOnline.API.Application.Features.Products.Mapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        Mapp();
    }
    void Mapp()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
