using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DataHolders
{
  public  class dhEmployeeValidator: AbstractValidator<dhEmployee>
    {
        public dhEmployeeValidator() {
            RuleFor(emp => emp.VTitle).NotNull().WithMessage("Please Enter Employee Title i.e. Mr.");
            RuleFor(emp => emp.DDateOfJoining).NotNull().WithMessage("Please Enter the Employee Joining Date");
            RuleFor(emp => emp.VEmpfName).NotNull().WithMessage("Please Enter the Employee Name.");
            RuleFor(emp => emp.IBasicSalary).NotNull().WithMessage("Please Enter Basic Salary.");
            RuleFor(emp => emp.VIdNumber).NotNull().WithMessage("Please Enter the Employee CNIC Number.");
            RuleFor(emp => emp.IMobile).NotNull().WithMessage("Please Enter the Employee Mobile Number.");
            RuleFor(emp => emp.VAddress).NotNull().WithMessage("Please Enter the Employee Address");
            //RuleFor(emp => emp.VEmpfName).NotNull().WithMessage("Please Enter the Employee Name.");
        }
    }
}

