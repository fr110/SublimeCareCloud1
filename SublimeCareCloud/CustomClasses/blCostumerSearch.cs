
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
  public  class blCostumerSearch : IIntelliboxResultsProvider
    {
        private List<dhCostumer> _results;

        private void ConstructResultSet(Boolean extraInfo=false)
        {
            dhCostumer objCostumer = new dhCostumer();
            dsGeneral.dtPOSCostumerDataTable dt;
            if (!extraInfo)
            {
              dt= iFacede.GetCostumer(Globalized.ObjDbName, objCostumer);
            }
            else
            {
                dt = iFacede.GetCostumerAlert(Globalized.ObjDbName, objCostumer);
            }
            _results = new List<dhCostumer>();
            foreach (DataRow row in dt.Rows)
            {

                _results.Add(new dhCostumer
                {
                    CostumerID = Convert.ToInt32(row["CostumerID"]),
                    CostumerName = Convert.ToString(row["CostumerName"]),
                    CostumerMobileNumber = Convert.ToString(row["CostumerMobileNumber"]),
                    CostumerBikeNumber = Convert.ToString(row["CostumerBikeNumber"]),
                    //MeterReading = Convert.ToString(row["MeterReading"]),
                    //ModelNumber = Convert.ToString(row["ModelNumber"]),
                    CostumerInfo = Convert.ToString(row["CostumerName"]) + " , " + Convert.ToString(row["CostumerBikeNumber"]) + " , " + Convert.ToString(row["CostumerMobileNumber"]),
                    //VItemName = Convert.ToString(row["VItemName"]),
                    //FMaxDiscountPresent = Convert.ToDouble(row["fMaxDiscountPresent"]),
                    //VCostumerMobile = Convert.ToString(row["VCostumerMobile"]),
                    //VCostumerName = Convert.ToString(row["ReadingInches"]),
                });
            }

        }

        //public IEnumerable<object> DoSearch(string searchTerm, int maxResults, object extraInfo)
        //{
        //    if ((extraInfo != null) && (extraInfo.ToString() == "true"))
        //    {
        //        ConstructResultSet(true);
        //    }else
        //    {
        //        ConstructResultSet();
        //    }
        //    //return _results.Cast<object>();
        //    searchTerm = searchTerm.ToLower();
        //    return _results.Where(term => term.CostumerInfo.ToString().ToLower().Contains(searchTerm) ).Take(maxResults).Cast<object>();
           
        //}

        IEnumerable IIntelliboxResultsProvider.DoSearch(string searchTerm, int maxResults, object extraInfo)
        {
            if ((extraInfo != null) && (extraInfo.ToString() == "true"))
            {
                ConstructResultSet(true);
            }
            else
            {
                ConstructResultSet();
            }
            //return _results.Cast<object>();
            searchTerm = searchTerm.ToLower();
            return _results.Where(term => term.CostumerInfo.ToString().ToLower().Contains(searchTerm)).Take(maxResults).Cast<object>();

        }
    }
}
