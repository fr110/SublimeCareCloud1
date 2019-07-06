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
    class blPurchase
    {
        dalGeneral objDALGeneral;
        public blPurchase()
        {
            objDALGeneral = new dalGeneral();
        }
       public DataSet InsertUpdatePurchase(dhDBnames dhDBnames, dhPurchase objPurchase)
        {

            DataSet ds;
            ds = objDALGeneral.InsertUpdatePurchase(dhDBnames, objPurchase);
            return ds;
        }

       public DataSet InsertUpdatePurchaseItem(dhDBnames dhDBnames, dhSaleItem item)
       {
           DataSet ds;
           ds = objDALGeneral.InsertUpdatePurchaseItem(dhDBnames, item);
           return ds;
       }

       public DataSet GetPurchase(dhDBnames dhDBnames, dhPurchase objPurchase)
       {
           DataSet ds;
           ds = objDALGeneral.GetPurchase(dhDBnames, objPurchase);
           return ds;
       }
    }
}
