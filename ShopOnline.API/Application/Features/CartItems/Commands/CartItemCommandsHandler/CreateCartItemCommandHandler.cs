using ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommands;
using ShopOnline.API.Specifications.CartItems;
using ShopOnline.API.Specifications.Carts;
using ShopOnline.API.Specifications.Products;
using ShopOnline.Models.CartItem;
namespace ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommandsHandler;

public sealed class CreateCartItemCommandHandler :
    IRequestHandler<CreateCartItemCommand, Response<CartItemDto>>
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;
    public CreateCartItemCommandHandler(IUnitOfWork context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<CartItemDto>>
        Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        if (request is null || request.Dto is null)
            return ResponseHandler.BadRequest<CartItemDto>();

        // check if product exist
        var isProductExistSpecification =
            new IsProductExistSpecification<Product>(request.Dto.ProductId);

        if (!await _context.Products.IsExistAsync(isProductExistSpecification))
            return ResponseHandler.NotFound<CartItemDto>();

        // check if cart item exist
        var isCartExistSpecification =
            new IsCartExistSpecification<Cart>(request.Dto.CartId);

        if (!await _context.Carts.IsExistAsync(isCartExistSpecification))
            return ResponseHandler.NotFound<CartItemDto>();

        // mapp from dto to model
        var model = _mapper.Map<CartItem>(request.Dto);

        // begin transactiom
        var transaction = await _context.BeginTransactionAsync(cancellationToken);
        try
        {
            // create new CartItem
            await _context.CartItems.CreateAsync(model);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            var cartItemByIdIncludedProductSpecificatoin = new
                 CartItemByIdIncludedProductSpecificatoin<CartItem>(request.Dto.ProductId);

            // get cart item included product data
            var cartItem = await _context.CartItems.RetriveWithSpecificationAsync(cartItemByIdIncludedProductSpecificatoin);
            var dto = _mapper.Map<CartItemDto>(cartItem);
            return ResponseHandler.Success(dto);
        }
        catch
        {
            await transaction.RollbackAsync();
            return ResponseHandler.Conflict<CartItemDto>();
        }

    }
}
