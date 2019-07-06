using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using DataHolders;

namespace BL
{
  public  class blCostumer
  { 
      dalGeneral objDALGeneral;

      public blCostumer()
        {
            objDALGeneral = new dalGeneral();
        }
    
      internal dsGeneral.dtPOSCostumerDataTable GetCostumer(dhDBnames objDBNames,dhCostumer objCostumer)
      {
          dsGeneral.dtPOSCostumerDataTable dt = objDALGeneral.GetCostumer(objDBNames, objCostumer);
          return dt;
      }
      internal dsGeneral.dtPOSCostumerDataTable GetCostumerAlert(dhDBnames objDBNames, dhCostumer objCostumer)
      {
          dsGeneral.dtPOSCostumerDataTable dt = objDALGeneral.GetCostumerAlert(objDBNames, objCostumer);
          return dt;
      }
      internal DataSet InsertUpdateCostumer(dhDBnames objDBNames, dhCostumer objCostumer)
      {
          DataSet ds;
          ds = objDALGeneral.InsertUpdateCostumer(objDBNames, objCostumer);
          return ds;
      }
  }
}
