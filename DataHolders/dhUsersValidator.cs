using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhUsersValidator : AbstractValidator<dhUsers>
    {
        public dhUsersValidator()
        {
            //RuleFor(User => User.VPassword).NotEqual(u => u.VcPassword).WithMessage("User is Required.");

            RuleFor(User => User.VfName).NotEmpty().WithMessage("User First Name is Required.");
            RuleFor(User => User.VfName).NotNull().WithMessage("User First Name is Required.");

            RuleFor(User => User.VlName).NotEmpty().WithMessage("User last name is Required.");
            RuleFor(User => User.VlName).NotNull().WithMessage("User last name is Required.");

            RuleFor(User => User.VEmail).NotEmpty().WithMessage("User Email Address is Required.");
            RuleFor(User => User.VEmail).EmailAddress().WithMessage("User Email Address is Required.");

            RuleFor(User => User.VLogin).NotEmpty().WithMessage("User Login name  is Required.");
            RuleFor(User => User.VLogin).NotNull().WithMessage("User Login name  is Required.");
         //   RuleFor(User => User.VUserType).NotNull().WithMessage("User is Required.");
            RuleFor(User => User.DDOB).NotNull().WithMessage("User Date of birthday is Required.");
            //RuleFor(User => User.VPassword).NotNull().WithMessage("User is Required.");

        }
    }
}
