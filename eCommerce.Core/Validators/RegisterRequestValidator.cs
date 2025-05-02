using eCommerce.Core.DTO;

using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            //Email
            RuleFor(request => request.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is not valid");

            //Password
            RuleFor(request => request.Password)
                .NotEmpty()
                .WithMessage("Password is required");

            //PersonName
            RuleFor(request => request.PersonName)
                .NotEmpty()
                .WithMessage("PersonName is required")
                .Length(1, 50)
                .WithMessage("PersonName must be between 1 and 50 characters");

            //Gender
            RuleFor(request => request.Gender)
                .IsInEnum()
                .WithMessage("Gender must be Male, Female, or Other");
        }
    }
}