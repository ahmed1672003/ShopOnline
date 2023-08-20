using ShopOnline.Models.Category;

namespace ShopOnline.API.Application.Features.Categories.Queries.CategoryQueries;

public sealed record RetrieveAllCategoriesQuery() : IRequest<Response<IEnumerable<CategoryDto>>>;
