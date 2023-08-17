namespace ShopOnline.API.Application.Features.Products.Queries.ProductQueries;

public sealed record RetrieveProductByIdQuery(int? Id) : IRequest<Response<ProductDto>>;
