using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
  public  class dhJournalValidator: AbstractValidator<dhJournal>
    {
      public dhJournalValidator()
        {
            RuleFor(JrDetail => JrDetail.VTranTitle).NotNull().WithMessage("Please Enter Transaction Title .");
            RuleFor(JrDetail => JrDetail.DTransactionDate).NotEmpty().WithMessage("Please Select Date.");
           
            //RuleFor(JrDetail => JrDetail.).NotEmpty().WithMessage("Please Enter Party Name.");
       }

    }
}
