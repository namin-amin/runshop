using FluentValidation;
using runShop.rest.Dtos.user;

namespace runShop.rest.Validations.user;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(c => c.Email).NotEmpty().EmailAddress();

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(8);

        RuleFor(c => c.FirstName).NotEmpty().MinimumLength(2);

        RuleFor(c => c.Password).NotEmpty().WithMessage("Your password cannot be empty")
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
    }
}