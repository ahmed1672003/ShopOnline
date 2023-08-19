using ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommands;

namespace ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommandsValidators;

public sealed class DeleteCartItemCommandValidator : AbstractValidator<DeleteCartItemCommand>
{
    public DeleteCartItemCommandValidator()
    {
        CheckValidation();
    }

    void CheckValidation()
    {
        RuleFor(c => c.Id).NotNull().NotEmpty();
    }
}
