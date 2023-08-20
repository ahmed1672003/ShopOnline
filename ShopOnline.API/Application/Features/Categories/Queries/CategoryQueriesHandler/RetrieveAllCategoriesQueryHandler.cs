using ShopOnline.API.Application.Features.Categories.Queries.CategoryQueries;
using ShopOnline.Models.Category;

namespace ShopOnline.API.Application.Features.Categories.Queries.CategoryQueriesHandler;

public class RetrieveAllCategoriesQueryHandler :
    IRequestHandler<RetrieveAllCategoriesQuery, Response<IEnumerable<CategoryDto>>>
{
    private readonly IUnitOfWork _context;
    private readonly IMapper _mapper;

    public RetrieveAllCategoriesQueryHandler(IUnitOfWork context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<CategoryDto>>>
        Handle(RetrieveAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            return ResponseHandler.BadRequest<IEnumerable<CategoryDto>>();

        if (!await _context.Categories.IsExistAsync())
            return ResponseHandler.NotFound<IEnumerable<CategoryDto>>();

        var dtos =
            _mapper.Map<IEnumerable<CategoryDto>>(await _context.Categories.RetriveAllAsync());

        return ResponseHandler.Success(dtos);
    }
}
