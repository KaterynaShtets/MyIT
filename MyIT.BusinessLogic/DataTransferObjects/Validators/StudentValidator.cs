using FluentValidation;

namespace MyIT.BusinessLogic.DataTransferObjects.Validators;

public sealed class StudentValidator : AbstractValidator<StudentDto>
{
    public StudentValidator()
    {
        RuleFor(b => b.FullName).MinimumLength(1).MaximumLength(100);
        RuleFor(b => b.Email).EmailAddress();
    }
}


