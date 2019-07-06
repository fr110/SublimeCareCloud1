using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DataHolders
{
    public class dhCostumerValidator: AbstractValidator<dhCostumer>
    {
        public dhCostumerValidator()
        {
            RuleFor(Costumer => Costumer.CostumerBikeNumber).NotNull().WithMessage("Please Enter Costumer Bike Number");
            RuleFor(Costumer => Costumer.CostumerMobileNumber).NotNull().WithMessage("Please Enter Costumer Mobile Number");
            RuleFor(Costumer => Costumer.CostumerName).NotNull().WithMessage("Please Enter Costumer Name");
            RuleFor(Costumer => Costumer.MeterReading).NotNull().WithMessage("Please Enter Bike Meter Reading");
          //  RuleFor(Costumer => Costumer.ModelNumber).NotNull().WithMessage("Please Enter Bike Number");
          //  RuleFor(Costumer => Costumer.CostumerBikeNumber).NotNull().WithMessage("Please Enter Bike Number");
           // RuleFor(Costumer => Costumer.CostumerBikeNumber).NotNull().WithMessage("Please Enter Bike Number");
           // RuleFor(Costumer => Costumer.CostumerBikeNumber).NotNull().WithMessage("Please Enter Bike Number");
           // RuleFor(Costumer => Costumer.CostumerBikeNumber).NotNull().WithMessage("Please Enter Bike Number");
          //  RuleFor(Costumer => Costumer.CostumerBikeNumber).NotNull().WithMessage("Please Enter Bike Number");
          //  RuleFor(Costumer => Costumer.CostumerBikeNumber).NotNull().WithMessage("Please Enter Bike Number");
         
        }
    
    }
}
