using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;

namespace DataHolders
{
    public class dhSaleItemValidator : AbstractValidator<dhSaleItem>
    {
        public dhSaleItemValidator()
        {
            RuleFor(SaleItem => SaleItem.IQuantity).NotNull().WithMessage("Please Select Item to Add in invoice.");
            RuleFor(SaleItem => SaleItem.IQuantity).NotEqual(0).WithMessage("Please Select Item to Add in invoice.");
        }
    }
}
