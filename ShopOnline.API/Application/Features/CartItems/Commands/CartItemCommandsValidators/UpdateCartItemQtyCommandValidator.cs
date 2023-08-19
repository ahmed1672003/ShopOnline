using ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommands;

namespace ShopOnline.API.Application.Features.CartItems.Commands.CartItemCommandsValidators;

public sealed class UpdateCartItemQtyCommandValidator : AbstractValidator<UpdateCartItemQtyCommand>
{
    public UpdateCartItemQtyCommandValidator()
    {
        CheckValidation();
    }
    void CheckValidation()
    {
        RuleFor(c => c.Id).NotNull().NotEmpty();
        RuleFor(c => c.Dto.CartItemId).NotNull().NotEmpty();
        RuleFor(c => c.Dto.Qty).NotNull().NotEmpty();
    }

}
