using FluentValidation;

namespace DataHolders
{
    public class dhAppPreferenceValidator : AbstractValidator<dhAppPreference>
    {
        public dhAppPreferenceValidator()
        {
            RuleFor(app => app.VApplicationName).NotNull().WithMessage("Please Enter Application Name.");
            RuleFor(app => app.VApplicationName).NotEmpty().WithMessage("Please EnterApplication Name.");

            RuleFor(app => app.VCompanyName).NotNull().WithMessage("Please Enter Company Name.");
            RuleFor(app => app.VCompanyName).NotEmpty().WithMessage("Please Enter Company Name.");
        }
    }
}