namespace ShopOnline.API.Application.Features.Products.Queries.ProductQueries;

public sealed record RetrieveAllProductsQuery() : IRequest<Response<IEnumerable<ProductDto>>>;
