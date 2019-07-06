using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhAccountValidator:AbstractValidator<dhAccount>
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
