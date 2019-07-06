using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
    public class dhPurchaseValidator : AbstractValidator<dhPurchase>
    {
        public dhPurchaseValidator()
        {
          //  RuleFor(Purchase => Purchase.FAmmountRecived.ToString()).GreaterThan(Purchase => Purchase.FPayAbleAmount.ToString()).WithMessage("Please Enter Receiver Name.");
            RuleFor(Purchase => Purchase.Ddate).NotNull().WithMessage("Please Select a datae");
            RuleFor(Purchase => Purchase.Formnumber).NotNull().WithMessage("Please Enter Form Number.");

            RuleFor(Purchase => Purchase.FAmmountRecived).NotEqual(0).WithMessage("Paid Amount is missing.");
            RuleFor(Purchase => Purchase.FAmmountRecived).NotNull().WithMessage("Paid Amount is missing.");
            RuleFor(Purchase => Purchase.VpartyName).NotNull().WithMessage("Please Select a Party to Generate Purchase");
            //RuleFor(Purchase => Purchase.VVehicleNo).NotNull().WithMessage("Please Enter Vehicle Number.");
          //  RuleFor(Purchase => Purchase.VDriverName).NotNull().WithMessage("Please Enter the Driver Name.");
            RuleFor(Purchase => Purchase.Ftotalamount).NotNull().WithMessage("With Out Purchase Items can’t generate Purchase.");
            RuleFor(Purchase => Purchase.Ftotalamount).NotEqual(0).WithMessage("With Out Purchase Items can’t generate Purchase.");
            
            //RuleFor(Purchase => Purchase.VDeliveryExpense).NotNull().WithMessage("Please Enter Delivery Expense.");
          //  RuleFor(Purchase => Purchase.VVehicleNo).NotNull().WithMessage("Please Enter Vehicle Number.");
          ///  RuleFor(Purchase => Purchase.VDriverName).NotNull().WithMessage("Please Enter Driver Number.");
            //RuleFor(Purchase => Purchase.VSeason).NotNull().WithMessage("Please Select a Season.");
          //  RuleFor(Purchase => Purchase.VReciverName).NotNull().WithMessage("Please Enter Receiver Name.");
          //  RuleFor(Purchase => Purchase.IDiscountPersent).GreaterThan(100).WithMessage("Discount Could not be greater than 100 %");
            
           //FAmmountRecived
//FPayAbleAmount
           

        }

        public dhPurchaseValidator(string Name)
        {
            if( (Name!=null) && (Name == "Purchase"))
            {
            //  RuleFor(Purchase => Purchase.FAmmountRecived.ToString()).GreaterThan(Purchase => Purchase.FPayAbleAmount.ToString()).WithMessage("Please Enter Receiver Name.");
            RuleFor(Purchase => Purchase.Ddate).NotNull().WithMessage("Please Select a datae");
            RuleFor(Purchase => Purchase.Formnumber).NotNull().WithMessage("Please Enter Form Number.");

        //    RuleFor(Purchase => Purchase.FAmmountRecived).NotEqual(0).WithMessage("Paid Amount is missing.");
            RuleFor(Purchase => Purchase.FAmmountRecived).NotNull().WithMessage("Paid Amount is missing.");
            RuleFor(Purchase => Purchase.VpartyName).NotNull().WithMessage("Please Select a Party to Generate Purchase");
            //RuleFor(Purchase => Purchase.VVehicleNo).NotNull().WithMessage("Please Enter Vehicle Number.");
            //RuleFor(Purchase => Purchase.VDriverName).NotNull().WithMessage("Please Enter the Driver Name.");
            RuleFor(Purchase => Purchase.Ftotalamount).NotNull().WithMessage("With Out Purchase Items can’t generate Purchase.");
            RuleFor(Purchase => Purchase.Ftotalamount).NotEqual(0).WithMessage("With Out Purchase Items can’t generate Purchase.");

            //RuleFor(Purchase => Purchase.VDeliveryExpense).NotNull().WithMessage("Please Enter Delivery Expense.");
            //RuleFor(Purchase => Purchase.VVehicleNo).NotNull().WithMessage("Please Enter Vehicle Number.");
            //RuleFor(Purchase => Purchase.VDriverName).NotNull().WithMessage("Please Enter Driver Number.");
            //RuleFor(Purchase => Purchase.VSeason).NotNull().WithMessage("Please Select a Season.");
        //    RuleFor(Purchase => Purchase.VReciverName).NotNull().WithMessage("Please Enter Receiver Name.");
            //  RuleFor(Purchase => Purchase.IDiscountPersent).GreaterThan(100).WithMessage("Discount Could not be greater than 100 %");
            }
            //FAmmountRecived
            //FPayAbleAmount


        }
    
    }
}
