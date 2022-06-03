using FluentValidation;

namespace MyIT.BusinessLogic.DataTransferObjects.Validators;

public class PsychologistValidator : AbstractValidator<PsychologistDto>
{

    public PsychologistValidator()
    {
        RuleFor(b => b.FullName).MinimumLength(1).MaximumLength(100);
        RuleFor(b => b.Email).EmailAddress();
        RuleFor(b => b.DOB).NotEmpty()
            .LessThan(p => DateTime.Now).Must(BeAValidAge);
    }

    private bool BeAValidAge(DateTime date)
    {
        int currentYear = DateTime.Now.Year;
        int dobYear = date.Year;

        if (dobYear < (currentYear - 16) && dobYear > (currentYear - 120))
        {
            return true;
        }

        return false;
    }
}
