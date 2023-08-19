using ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommands;
using ShopOnline.API.Specifications.CartItems;
using ShopOnline.Models.CartItem;

namespace ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommandsHandler;

public sealed class DeleteCartItemCommandHandler :
    IRequestHandler<DeleteCartItemCommand, Response<CartItemDto>>
{
    private readonly IUnitOfWork _context;
    public DeleteCartItemCommandHandler(IUnitOfWork context)
    {
        _context = context;
    }
    public async Task<Response<CartItemDto>>
        Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        if (request is null || request.Id is null)
            return ResponseHandler.BadRequest<CartItemDto>();

        var isCartItemExistSpecification =
            new IsCartItemExistSpecification<CartItem>(request.Id.Value);

        if (!await _context.CartItems.IsExistAsync(isCartItemExistSpecification, cancellationToken))
            return ResponseHandler.NotFound<CartItemDto>();

        var deleteCartItemSpecification =
            new DeleteCartItemSpecification<CartItem>(request.Id.Value);

        var result = await _context.CartItems.ExecuteDeleteAsync(deleteCartItemSpecification);

        return result == 1 ? ResponseHandler.Success<CartItemDto>() : ResponseHandler.Conflict<CartItemDto>();
    }
}
