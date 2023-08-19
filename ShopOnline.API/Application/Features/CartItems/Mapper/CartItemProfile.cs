using ShopOnline.Models.CartItem;

namespace ShopOnline.API.Application.Features.CartItems.Mapper;

public sealed class CartItemProfile : Profile
{
    public CartItemProfile()
    {
        Mapp();
    }
    void Mapp()
    {
        CreateMap<CartItemToAddDto, CartItem>();

        CreateMap<CartItem, CartItemDto>()
            .ForMember(dist => dist.ProductImageURL, cfg =>
            cfg.MapFrom(src => src.Product.ImageURL))
            .ForMember(dist => dist.ProductName, cfg =>
            cfg.MapFrom(src => src.Product.Name))
            .ForMember(dist => dist.ProductDescription, cfg =>
            cfg.MapFrom(src => src.Product.Description))
            .ForMember(dist => dist.Price, cfg =>
            cfg.MapFrom(src => src.Product.Price))
            .ForMember(dist => dist.TotalPrice, cfg =>
            cfg.MapFrom(src => (src.Qty * src.Product.Price)));
    }
}
