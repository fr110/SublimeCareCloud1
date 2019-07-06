using DataHolders;
using FeserWard.Controls;
using iFacedeLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SublimeCareCloud.CustomClasses
{
    class blEmploySearch : IIntelliboxResultsProvider
    {
        private List<dhEmployee> _results;

        private void ConstructResultSet()
        {
            dhEmployee objEmployee = new dhEmployee();
            dsGeneral.dtEmployeeDataTable dt = iFacede.GetEmployee(Globalized.ObjDbName, objEmployee);
            _results = new List<dhEmployee>();
            foreach (DataRow row in dt.Rows)
            {

                _results.Add(new dhEmployee
                {
                    IEmpid = Convert.ToInt32(row["iEmpid"]),
                    VEmpfName = Convert.ToString(row["vEmpfName"]),
                    IMobile = Convert.ToString(row["iMobile"]),
                    VEmployeeInfo = Convert.ToString(row["vEmpfName"]) + " , " + Convert.ToString(row["VAddress"]) + " , " + Convert.ToString(row["iMobile"]),
                    //VItemName = Convert.ToString(row["VItemName"]),
                    //FMaxDiscountPresent = Convert.ToDouble(row["fMaxDiscountPresent"]),
                    //VEmployeeMobile = Convert.ToString(row["VEmployeeMobile"]),
                    //VEmployeeName = Convert.ToString(row["ReadingInches"]),
                });
            }

        }

        //public IEnumerable<object> DoSearch(string searchTerm, int maxResults, object extraInfo)
        //{
        //    ConstructResultSet();
        //    //return _results.Cast<object>();
        //    searchTerm = searchTerm.ToLower();
        //    return _results.Where(term => term.VEmployeeInfo.ToString().ToLower().Contains(searchTerm)).Take(maxResults).Cast<object>();

        //}

        IEnumerable IIntelliboxResultsProvider.DoSearch(string searchTerm, int maxResults, object extraInfo)
        {
            ConstructResultSet();
            //return _results.Cast<object>();
            searchTerm = searchTerm.ToLower();
            return _results.Where(term => term.VEmployeeInfo.ToString().ToLower().Contains(searchTerm)).Take(maxResults).Cast<object>();

        }
    }
}