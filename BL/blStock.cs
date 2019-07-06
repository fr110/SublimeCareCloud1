using DAL;
using DataHolders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class blStock
   {
       dalGeneral objDALGeneral;
       public blStock()
       {
           objDALGeneral = new dalGeneral();
       }
       internal dsGeneral.dtPosStockDataTable GetItemStock(DataHolders.dhDBnames objDBNames,dhItemStock objStock)
        {
            dsGeneral.dtPosStockDataTable dt = objDALGeneral.GetItemStock(objDBNames, objStock);
            return dt;
        }

       internal DataSet InsertUpdateStock(dhDBnames objDBNames, dhItemStock objStock)
       {
           DataSet ds;
           ds = objDALGeneral.InsertUpdateStock(objDBNames, objStock);
           return ds;
       }

   }
}
