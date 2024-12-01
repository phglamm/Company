namespace Company.Validator;

using Company.DTO.UserDTO;
using FluentValidation;

public class UserPostValidator : AbstractValidator<UserPost>
{
    public UserPostValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(10, 100).WithMessage("Name must be between 10 and 100 characters");


        RuleFor(user => user.Age)
            .InclusiveBetween(18, 100).WithMessage("Age must be between 18 and 100");

        RuleFor(user => user.Username)
            .NotEmpty().WithMessage("Username is required")
            .Length(3, 10).WithMessage("Username must be between 3 and 10 characters");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters");

        RuleFor(user => user.DepartmentId)
            .NotEmpty().WithMessage("DepartmentId is required");
        //RuleFor(user => user.Email)
        //    .EmailAddress().WithMessage("Invalid email format");
    }
}

