using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhPartyValidator: AbstractValidator<dhParty>
    {
        public dhPartyValidator()
        {
            RuleFor(Party => Party.VPartyName).NotNull().WithMessage("Please Enter Party Name.");
            RuleFor(Party => Party.VPartyName).NotEmpty().WithMessage("Please Enter Party Name.");
            // RuleFor(party => party.VPartyName).EmailAddress().WithMessage("Please Specify a Valid E-Mail Address");
            //RuleFor(Party => Party.VMarket).NotNull().WithMessage("Please Enter Market information.");
            //RuleFor(Party => Party.VArea).NotNull().WithMessage("Please Enter Area information.");
            //RuleFor(Party => Party.VDistrict).NotNull().WithMessage("Please Enter District information.");
            //RuleFor(Party => Party.VCity).NotNull().WithMessage("Please Enter City information.");
            RuleFor(Party => Party.VpartyMobile).NotNull().WithMessage("Please Enter Party Contact Number");
            ////RuleFor(Party => Party.ICreditLimit).NotEqual(0).WithMessage("Please Select a Salesman.");
            ////RuleFor(Party => Party.VPartyadress).NotNull().WithMessage("Please Enter Party Address.");
            //RuleFor(Party => Party.ISaleManID).NotNull().WithMessage("Please Select a Salesman.");
            //RuleFor(Party => Party.ISaleManID).NotEqual(0).WithMessage("Please Select a Salesman.");
            RuleFor(Party => Party.VContactPerson).NotNull().WithMessage("Please Enter Contact Person information.");
            // RuleFor(Party => Party.VLandlineNumber).NotNull().WithMessage("Please Enter Landline Number information.");
            RuleFor(Party => Party.VLandlineNumber).NotNull().Length(0, 255).WithMessage("Please Enter Landline Number information.");

            //RuleFor(Party => Party.).NotNull().WithMessage("Please Select a Salesman.");

        }
    
    }
}
