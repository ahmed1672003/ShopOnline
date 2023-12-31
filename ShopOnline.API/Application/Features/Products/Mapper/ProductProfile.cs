﻿namespace ShopOnline.API.Application.Features.Products.Mapper;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        Mapp();
    }
    void Mapp()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dist => dist.CategoryName, cfg =>
            cfg.MapFrom(src => src.Name));
    }
}
