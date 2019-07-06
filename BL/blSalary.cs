using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


using DataHolders;
using DAL;

namespace BL
{

   public class blSalary
    {
        dalGeneral objDALGeneral;      // Dal Object To Use
        // Constrector of the Class
        public blSalary() 
        {
            objDALGeneral = new dalGeneral();
        }

        public dsGeneral.dtSalaryDataTable GetSalary(dhDBnames objDBNames, dhSalary objSalary)
        {
            dsGeneral.dtSalaryDataTable dt = objDALGeneral.GetSalary(objDBNames,objSalary);
            return dt;
        }
        public dsGeneral.dtSalaryDataTable GetSalaryMonthlyReportSheet(dhDBnames objDBNames, dhSalary objSalary)
        {
            dsGeneral.dtSalaryDataTable dt = objDALGeneral.GetSalaryMonthlyReportSheet(objDBNames, objSalary);
            return dt;
        }

        public dsGeneral.dtSalaryDataTable GetSalarySheetHrEmployee(dhDBnames objDBNames, dhSalary objSalary)
        {
            dsGeneral.dtSalaryDataTable dt = objDALGeneral.GetSalarySheetHrEmployee(objDBNames, objSalary);
            return dt;
        }
        public DataSet InsertUpdateSalary(dhDBnames objDBNames, dhSalary objSalary)
        {
            DataSet ds;
            ds = objDALGeneral.InsertUpdateSalary(objDBNames, objSalary);
            return ds;
        }
 
    }
}
