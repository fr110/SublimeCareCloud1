using FluentValidation;

namespace DataHolders
{
    public class dhAccountValidator : AbstractValidator<dhAccount>
    {
        public dhAccountValidator()
        {
            RuleFor(Account => Account.AccountName).NotNull().WithMessage("Please Account Name .");
            RuleFor(Account => Account.VAccountNo).NotNull().WithMessage("Please Account Number.");
            //    RuleFor(Account => Account.IFinaceType).NotNull().WithMessage("Please Select Account Type.");
            //Name
            //Number
            //Type
        }
    }
}