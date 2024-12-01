using Company.DTO.DepartmentDTO;
using FluentValidation;

namespace Company.Validator
{
    public class DepartmentPostValidator : AbstractValidator<DepartmentPost>
    {
        public DepartmentPostValidator()
        {
            RuleFor(user => user.DepartmentName)
                .NotEmpty().WithMessage("DepartmentName is required")
                .Length(5, 30).WithMessage("DepartmentName must be between 5 and 30 characters");
        }
    }
}
