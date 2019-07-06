
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using DataHolders;
using DAL;

namespace BL
{

    public class blEmployee
    {
        dalGeneral objDALGeneral;


        public blEmployee()
        {
            objDALGeneral = new dalGeneral();
        }
        public dsGeneral.dtEmployeeDataTable GetEmployee(dhDBnames objDBNames, dhEmployee objEmployee)
        {
            dsGeneral.dtEmployeeDataTable dt = objDALGeneral.GetEmployee(objDBNames, objEmployee);
            return dt;
        }
        public DataSet InsertUpdateEmployee(dhDBnames objDBNames, dhEmployee objEmployee)
        {
            DataSet ds;
            ds = objDALGeneral.InsertUpdateEmployee(objDBNames, objEmployee);
            return ds;
        }


        //public dsGeneral.dtEmployeeTimesheetDataTable GetEmployeeTimeSheet(dhDBnames objDBNames, dhEmployeeTimeSheet objEmpTime)
        //{
        //    dsGeneral.dtEmployeeTimesheetDataTable dt = objDALGeneral.GetEmployeeTimeSheet(objDBNames, objEmpTime);
        //    return dt;
        //}
        //public dsGeneral.dtEmployeeTimesheetDataTable GetEmployeeTimeSheetEndDate(dhDBnames objDBNames, dhEmployeeTimeSheet objEmpTime)
        //{
        //    dsGeneral.dtEmployeeTimesheetDataTable dt = objDALGeneral.GetEmployeeTimeSheetEndDate(objDBNames, objEmpTime);
        //    return dt;
        //}
        //public DataSet InsertUpdateEmployeeTimeSheet(dhDBnames objDBNames, dhEmployeeTimeSheet objEmpTime)
        //{
        //    DataSet ds;
        //    ds = objDALGeneral.InsertUpdateEmployeeTimeSheet(objDBNames, objEmpTime);
        //    return ds;
        //}



        //public dsGeneral.dtEmployeeAssignmentDataTable GetEmployeeAssignment(dhDBnames objDBNames, dhEmployeeAssignment objEmpAssign)
        //{
        //    dsGeneral.dtEmployeeAssignmentDataTable dt = objDALGeneral.GetEmployeeAssignment(objDBNames, objEmpAssign);
        //    return dt;
        //}

        //public DataSet InsertUpdateExpense(dhDBnames objDBNames, dhEmployeeAssignment objEmpAssign)
        //{
        //    DataSet ds;
        //    ds = objDALGeneral.InsertUpdateEmployeeAssignment(objDBNames, objEmpAssign);
        //    return ds;
        //}
    }
}
