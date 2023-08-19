using ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommands;

namespace ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommandsValidators;

public sealed class CreateCartItemCommandValidator : AbstractValidator<CreateCartItemCommand>
{

    public CreateCartItemCommandValidator()
    {
        CheckValidation();
    }
    void CheckValidation()
    {
        RuleFor(c => c.Dto.ProductId)
            .NotEmpty()
            .NotNull();

        RuleFor(c => c.Dto.CartId)
            .NotEmpty()
            .NotNull();

        RuleFor(c => c.Dto.Qty)
            .NotEmpty()
            .NotNull()
            .NotEqual(0);
    }
}
