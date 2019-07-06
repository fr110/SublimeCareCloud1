using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHolders
{
   public class dhProductionValidator: AbstractValidator<dhProduction>
    {
       public dhProductionValidator()
        {
//          IProductionId
//DDate
//VLocation
//VProductionManager
//VProductionUnit
//FProductionCast
            RuleFor(Production => Production.DDate).NotNull().WithMessage("Please Select a date.");
            RuleFor(Production => Production.VLocation).NotNull().WithMessage("Please Enter Location.");
            RuleFor(Production => Production.VPurchaseManager).NotNull().WithMessage("Please Enter Purchase Manager Name.");
            RuleFor(Production => Production.VProductionUnit).NotNull().WithMessage("Please Enter Production Unit.");
            RuleFor(Production => Production.FProductionCast).NotNull().WithMessage("Please Enter Production Cast.");
            RuleFor(Production => Production.ItemsConsumed).NotNull().WithMessage("Select Consumed Item(s) ");
            RuleFor(Production => Production.ItemsProduced).NotNull().WithMessage("Select Produced Item(s) ");
        }
    
    }
}
