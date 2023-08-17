using ShopOnline.API.Application.Features.Products.Queries.ProductQueries;
using ShopOnline.API.Specifications.Products;

namespace ShopOnline.API.Application.Features.Products.Queries.ProductQueriesHandlers;

public sealed class RetrieveProductByIdQueryHandler :
    IRequestHandler<RetrieveProductByIdQuery, Response<ProductDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public RetrieveProductByIdQueryHandler(
        IUnitOfWork context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    #endregion

    #region Handelr

    public async Task<Response<ProductDto>>
        Handle(RetrieveProductByIdQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            return ResponseHandler.BadRequest<ProductDto>();

        var productByIdSpecification = new ProductByIdSpecification<Product>(request.Id.Value);

        var model = await _context.Products.RetriveWithSpecificationAsync(productByIdSpecification, cancellationToken);

        if (model is null)
            return ResponseHandler.NotFound<ProductDto>();

        var result = _mapper.Map<ProductDto>(model);

        return ResponseHandler.Success(result);
    }
    #endregion
}