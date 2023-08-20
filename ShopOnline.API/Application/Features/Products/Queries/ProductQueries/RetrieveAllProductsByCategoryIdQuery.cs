namespace ShopOnline.API.Application.Features.Products.Queries.ProductQueries;

public sealed record RetrieveAllProductsByCategoryIdQuery(int? CategoryId) : IRequest<Response<IEnumerable<ProductDto>>>;

