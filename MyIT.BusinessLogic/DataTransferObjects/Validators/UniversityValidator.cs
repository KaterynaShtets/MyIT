using FluentValidation;

namespace MyIT.BusinessLogic.DataTransferObjects.Validators;

public class UniversityValidator  : AbstractValidator<UniversityDto>
{

    public UniversityValidator()
    {
        RuleFor(b => b.Name).MinimumLength(1).MaximumLength(100);
        RuleFor(b => b.Country).MinimumLength(1).MaximumLength(100);
        RuleFor(b => b.City).MinimumLength(1).MaximumLength(100);
        RuleFor(b => b.SiteUrl).Url();
        RuleFor(b => b.EmailDomain).MinimumLength(1).MaximumLength(100);
    }

}

public static class Validations
{
    public static IRuleBuilderOptions<T, string> Url<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        bool UrlIsValidUri(string url) => Uri.TryCreate(url, UriKind.Absolute, out var outUri)
                                          && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        return ruleBuilder.Must(UrlIsValidUri);
    }
}