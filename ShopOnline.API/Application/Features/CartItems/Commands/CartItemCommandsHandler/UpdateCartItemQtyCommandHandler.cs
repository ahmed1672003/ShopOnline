using ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommands;
using ShopOnline.API.Specifications.CartItems;
using ShopOnline.Models.CartItem;

namespace ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommandsHandler;

public sealed class UpdateCartItemQtyCommandHandler :
    IRequestHandler<UpdateCartItemQtyCommand, Response<CartItemDto>>
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;

    public UpdateCartItemQtyCommandHandler(IUnitOfWork context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<CartItemDto>>
        Handle(UpdateCartItemQtyCommand request, CancellationToken cancellationToken)
    {
        if (request is null || request.Dto is null || request.Id is null)
            return ResponseHandler.BadRequest<CartItemDto>();

        // check cart item is exist
        var isCartItemExistSpecification =
            new IsCartItemExistSpecification<CartItem>(request.Id.Value);

        if (!await _context.CartItems.IsExistAsync(isCartItemExistSpecification))
            return ResponseHandler.NotFound<CartItemDto>();

        // get cart item
        var updateCartItemQtySpecification =

            new UpdateCartItemQtySpecification<CartItem>(request.Id.Value);

        // begin transactiom
        var model = await _context.CartItems.RetriveWithSpecificationAsync(updateCartItemQtySpecification);
        var transaction = await _context.BeginTransactionAsync(cancellationToken);
        try
        {
            // update cart item
            model.Qty = request.Dto.Qty;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            var dto = _mapper.Map<CartItemDto>(model);
            return ResponseHandler.Success(dto);
        }
        catch
        {
            await transaction.RollbackAsync();
            return ResponseHandler.Conflict<CartItemDto>();
        }
    }
}