using ShopOnline.API.Application.Features.Products.Queries.ProductQueries;
using ShopOnline.API.Specifications.Categories;
using ShopOnline.API.Specifications.Products;

namespace ShopOnline.API.Application.Features.Products.Queries.ProductQueriesHandlers;

public sealed class RetrieveAllProductsByCategoryIdQueryHandler :
    IRequestHandler<RetrieveAllProductsByCategoryIdQuery, Response<IEnumerable<ProductDto>>>
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;

    public RetrieveAllProductsByCategoryIdQueryHandler(IUnitOfWork context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<ProductDto>>>
        Handle(RetrieveAllProductsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            return ResponseHandler.BadRequest<IEnumerable<ProductDto>>();

        var isCategoryExistSpecification =
            new IsCategoryExistSpecification<Category>(request.CategoryId.Value);

        if (!await _context.Categories.IsExistAsync(isCategoryExistSpecification))
            return ResponseHandler.NotFound<IEnumerable<ProductDto>>();

        var allProductsByCategoryIdSpecification =
            new AllProductsByCategoryIdSpecification<Product>(request.CategoryId.Value);

        var dtos = _mapper.Map<IEnumerable<ProductDto>>(await _context.Products.RetriveAllWithSpecificationAsync(allProductsByCategoryIdSpecification));

        if (!dtos.Any())
            return ResponseHandler.NotFound<IEnumerable<ProductDto>>();

        return ResponseHandler.Success(dtos);

    }
}
