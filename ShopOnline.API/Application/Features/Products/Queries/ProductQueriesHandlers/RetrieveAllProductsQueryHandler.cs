using ShopOnline.API.Application.Features.Products.Queries.ProductQueries;
using ShopOnline.API.Specifications.Products;

namespace ShopOnline.API.Application.Features.Products.Queries.ProductQueriesHandlers;

public sealed class RetrieveAllProductsQueryHandler :
    IRequestHandler<RetrieveAllProductsQuery, Response<IEnumerable<ProductDto>>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public RetrieveAllProductsQueryHandler(
        IUnitOfWork context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    #endregion

    #region Handler
    public async Task<Response<IEnumerable<ProductDto>>>
   Handle(RetrieveAllProductsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            return ResponseHandler.BadRequest<IEnumerable<ProductDto>>();

        var allProductsSpecification = new AllProductsSpecification<Product>();

        var models = await _context.Products.RetriveAllWithSpecificationAsync(allProductsSpecification);

        if (models is null)
            return ResponseHandler.NotFound<IEnumerable<ProductDto>>();

        var result = _mapper.Map<IEnumerable<ProductDto>>(models);

        return ResponseHandler.Success(result);
    }
    #endregion
}
