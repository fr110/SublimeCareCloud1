using FluentValidation;

namespace DataHolders
{
    public class dhItemsValidator : AbstractValidator<dhItems>
    {
        public dhItemsValidator()
        {
            RuleFor(invoice => invoice.VItemName).NotEmpty().WithMessage("Please Enter Item Name.");
            RuleFor(invoice => invoice.VDetailName).NotNull().WithMessage("Please Enter Detail Name.");
            RuleFor(invoice => invoice.VCompanyName).NotNull().WithMessage("Please Enter Company Name for this Item.");
            RuleFor(invoice => invoice.FUnitePrice).NotNull().WithMessage("Please Enter Unit Price for this Item.");
            //RuleFor(emp => emp.FMaxDiscountPresent).NotNull().WithMessage("Please Enter Discount amount for this item.");
            RuleFor(invoice => invoice.VItemBarcode).NotNull().WithMessage("Please Enter the Item Barcode.");
            RuleFor(invoice => invoice.IAlertAmount).NotNull().WithMessage("Please Enter the Stock Alert.");
        }
    }
}