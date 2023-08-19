using ShopOnline.API.Application.Features.CartItems.Queries.CartItemQueries;

namespace ShopOnline.API.Application.Features.CartItems.Queries.CartItemQueriesValidators;

public class RetrieveUserCartItemsQueryValidator : AbstractValidator<RetrieveUserCartItemsQuery>
{
    public RetrieveUserCartItemsQueryValidator()
    {
        CheckValidation();
    }
    void CheckValidation()
    {
        RuleFor(c => c.UserId).NotNull().NotEmpty();
    }
}
