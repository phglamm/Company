using Company.DTO.UserDTO;
using FluentValidation;

namespace Company.Validator
{
    public class UserLoginValidator : AbstractValidator<UserLogin>
    {

        public UserLoginValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required")
                .Length(3, 50).WithMessage("Username must be between 3 and 10 characters");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters");

        }
    }
}
