using ShopOnline.API.Application.Features.Products.Queries.ProductQueries;

namespace ShopOnline.API.Application.Features.Products.Queries.ProductQueriesValidators;

public class RetrieveProductByIdValidator : AbstractValidator<RetrieveProductByIdQuery>
{
    public RetrieveProductByIdValidator()
    {
        CheckValidation();
    }

    void CheckValidation()
    {
        RuleFor(q => q.Id)
        .NotNull()
        .NotEmpty();
    }
}
