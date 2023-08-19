using ShopOnline.API.Application.Features.CartItems.Queries.CartItemQueries;
using ShopOnline.API.Specifications.Carts;
using ShopOnline.API.Specifications.Users;
using ShopOnline.Models.CartItem;

namespace ShopOnline.API.Application.Features.CartItems.Queries.CartItemQueriesHandler;

public sealed class RetrieveUserCartItemsQueryHandler :
    IRequestHandler<RetrieveUserCartItemsQuery, Response<IEnumerable<CartItemDto>>>
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;

    public RetrieveUserCartItemsQueryHandler(IUnitOfWork context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<IEnumerable<CartItemDto>>>
        Handle(RetrieveUserCartItemsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            return ResponseHandler.BadRequest<IEnumerable<CartItemDto>>();

        // check user is exist
        var isUserExistSpecification =
                new IsUserExistSpecification<User>(request.UserId.Value);

        if (!await _context.Users.IsExistAsync(isUserExistSpecification, cancellationToken))
            return ResponseHandler.NotFound<IEnumerable<CartItemDto>>();

        // check user is have cart
        var isUserHaveCartSpecification =
            new IsUserHaveCartSpecification<Cart>(request.UserId.Value);

        if (!await _context.Carts.IsExistAsync(isUserHaveCartSpecification, cancellationToken))
            return ResponseHandler.NotFound<IEnumerable<CartItemDto>>();

        //get user cart include his cart items 
        var userCartIncludedCartItems =
            new UserCartIncludedCartItems<Cart>(request.UserId.Value);
        try
        {
            var cart = await _context.Carts.RetriveWithSpecificationAsync(userCartIncludedCartItems, cancellationToken);

            // check cart contain cart items 
            if (!cart.CartItems.Any())
                return ResponseHandler.NotFound<IEnumerable<CartItemDto>>(message: "cart do not have items");

            var dtos = _mapper.Map<IEnumerable<CartItemDto>>(cart.CartItems);
            return ResponseHandler.Success(dtos);
        }
        catch
        {
            return ResponseHandler.Conflict<IEnumerable<CartItemDto>>();
        }
    }
}
