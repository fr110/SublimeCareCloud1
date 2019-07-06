using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
   public class dhJournalDetailValidator : AbstractValidator<dhJournalDetail>
    {
        public dhJournalDetailValidator()
        {
            //RuleFor(JrDetail => JrDetail.VVoucherNo).NotNull().WithMessage("Please Enter Voucher Number.");
            //RuleFor(JrDetail => JrDetail.VReceivedBy).NotEmpty().WithMessage("Please Enter Received By.");
            //RuleFor(JrDetail => JrDetail.VPaymentMode).NotEmpty().WithMessage("Please Select Payment Mode.");
            //RuleFor(JrDetail => JrDetail.Vdescription).NotEmpty().WithMessage("Please Enter Description.");
            //RuleFor(JrDetail => JrDetail.VBankAccountNumber).NotEmpty().WithMessage("Please Enter Bank Account Number.");
            //RuleFor(JrDetail => JrDetail.IChequeNumber).NotEmpty().WithMessage("Please Enter Check Number.");
            //RuleFor(JrDetail => JrDetail.).NotEmpty().WithMessage("Please Enter Party Name.");
       }
    }
}
