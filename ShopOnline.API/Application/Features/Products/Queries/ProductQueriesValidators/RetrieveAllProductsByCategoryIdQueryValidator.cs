using ShopOnline.API.Application.Features.Products.Queries.ProductQueries;

namespace ShopOnline.API.Application.Features.Products.Queries.ProductQueriesValidators;

public class RetrieveAllProductsByCategoryIdQueryValidator : AbstractValidator<RetrieveAllProductsByCategoryIdQuery>
{
    public RetrieveAllProductsByCategoryIdQueryValidator()
    {
        CheckValidation();
    }

    void CheckValidation()
    {
        RuleFor(q => q.CategoryId)
            .NotNull().NotEmpty();
    }
}
