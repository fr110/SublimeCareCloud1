using FluentValidation;

namespace DataHolders
{
    public class dhInvoiceValidator : AbstractValidator<dhInvoice>
    {
        public dhInvoiceValidator()
        {
            //  RuleFor(emp => emp.FAmmountRecived.ToString()).GreaterThan(emp => emp.FPayAbleAmount.ToString()).WithMessage("Please Enter Receiver Name.");
            RuleFor(invoice => invoice.Ddate).NotNull().WithMessage("Please Select a datae");
            RuleFor(invoice => invoice.FAmmountRecived).NotEqual(0).WithMessage("Received Amount is missing.");
            RuleFor(invoice => invoice.FAmmountRecived).NotNull().WithMessage("Received Amount is missing.");
            // RuleFor(emp => emp.VpartyName).NotNull().WithMessage("Please Select a Party to Generate Invoice");
            // RuleFor(emp => emp.VVehicleNo).NotNull().WithMessage("Please Enter Vehicle Number.");
            //RuleFor(emp => emp.VDriverName).NotNull().WithMessage("Please Enter the Driver Name.");
            RuleFor(invoice => invoice.Ftotalamount).NotNull().WithMessage("With Out Invoice Items can’t generate invoice.");
            RuleFor(invoice => invoice.Ftotalamount).NotEqual(0).WithMessage("With Out Invoice Items can’t generate invoice.");

            // RuleFor(emp => emp.VDeliveryExpense).NotNull().WithMessage("Please Enter Delivery Expense.");
            //RuleFor(emp => emp.VVehicleNo).NotNull().WithMessage("Please Enter Vehicle Number.");
            // RuleFor(emp => emp.VDriverName).NotNull().WithMessage("Please Enter Driver Number.");
            //RuleFor(emp => emp.VSeason).NotNull().WithMessage("Please Select a Season.");
            //RuleFor(emp => emp.VReciverName).NotNull().WithMessage("Please Enter Receiver Name.");
            //  RuleFor(emp => emp.IDiscountPersent).GreaterThan(100).WithMessage("Discount Could not be greater than 100 %");

            //FAmmountRecived
            //FPayAbleAmount
        }
    }
}